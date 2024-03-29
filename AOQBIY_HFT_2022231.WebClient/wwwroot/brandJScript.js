﻿function backtomain() {
    window.location.assign("index.html");
}
let brandcoll = [];
let connection;
let brandIdToUpdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl('http://localhost:25922/hub')
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on("BrandCreated", (user, message) => {
        getdata();
    });
    connection.on("BrandDeleted", (user, message) => {
        getdata();
    });
    connection.on("BrandUpdated", (user, message) => {
        getdata();
    });
    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
}
async function getdata() {
    await fetch('http://localhost:25922/Brand')
        .then(x => x.json())
        .then(y => {
            brandcoll = y;
            console.log(brandcoll)
            display();
        });
}
function display() {
    document.getElementById('resultareabrand').innerHTML = "";
    brandcoll.forEach(t =>
    {
        document.getElementById('resultareabrand').innerHTML +=
            "<tr><td>" + t.brandId + "</td><td>"
        + t.name + "</td><td>" + `<button type="button" onclick="remove(${t.brandId})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.brandId})">Update</button>` +
            "</td></tr>";
        console.log(t);
    })
}
function showupdate(id) {
    document.getElementById('brandnametoupdate').value = brandcoll.find(t => t['brandId'] == id)['name'];
    document.getElementById('updateformdiv').style.display = "flex";
    brandIdToUpdate = id;
}
function update() {
    document.getElementById('updateformdiv').style.display = "none";
    let namen = document.getElementById('brandnametoupdate').value;
    fetch('http://localhost:25922/Brand', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                name: namen,
                brandId: brandIdToUpdate,
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function remove(id) {
    fetch('http://localhost:25922/Brand/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function create() {
    let namen = document.getElementById('brandname').value;
    fetch('http://localhost:25922/Brand', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                name: namen,
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}