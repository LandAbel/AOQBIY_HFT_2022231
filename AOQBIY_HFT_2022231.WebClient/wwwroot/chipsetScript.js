function backtomain() {
    window.location.assign("index.html");
}
let chipsetcoll = [];
let chipsetIdToUpdate = -1;
let connection;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl('http://localhost:25922/hub')
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on("ChipsetCreated", (user, message) => {
        getdata();
    });
    connection.on("ChipsetDeleted", (user, message) => {
        getdata();
    });
    connection.on("ChipsetUpdated", (user, message) => {
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
    await fetch('http://localhost:25922/Chipset')
        .then(x => x.json())
        .then(y => {
            chipsetcoll = y;
            console.log(chipsetcoll)
            display();
        });
}
function display() {
    document.getElementById('resultareachipset').innerHTML = "";
    chipsetcoll.forEach(t => {
        document.getElementById('resultareachipset').innerHTML +=
            "<tr><td>" + t.chipsetId + "</td><td>"
            + t.name + "</td><td>" + `<button type="button" onclick="remove(${t.chipsetId})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.chipsetId})">Update</button>` +
            "</td></tr>";
        console.log(t);
    })
}
function showupdate(id) {
    document.getElementById('chipsetnametoupdate').value = chipsetcoll.find(t => t['chipsetId'] == id)['name'];
    document.getElementById('chipsetupdateformdiv').style.display = "flex";
    chipsetIdToUpdate = id;
}
function update() {
    document.getElementById('chipsetupdateformdiv').style.display = "none";
    let namen = document.getElementById('chipsetnametoupdate').value;
    fetch('http://localhost:25922/Chipset', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                name: namen,
                chipsetId: chipsetIdToUpdate,
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
    fetch('http://localhost:25922/Chipset' + id, {
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
    let namen = document.getElementById('chipsetname').value;
    fetch('http://localhost:25922/Chipset', {
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