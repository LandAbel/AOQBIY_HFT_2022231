function backtomain() {
    window.location.assign("index.html");
}

let processorcoll = [];
let connection;
let processorIdToUpdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl('http://localhost:25922/hub')
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on("ProcessorCreated", (user, message) => {
        getdata();
    });
    connection.on("ProcessorDeleted", (user, message) => {
        getdata();
    });
    connection.on("ProcessorUpdated", (user, message) => {
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
    await fetch('http://localhost:25922/Processor')
        .then(x => x.json())
        .then(y => {
            processorcoll = y;
            console.log(processorcoll)
            display();
        });
}
function display() {
    document.getElementById('ResultAreAProcessor').innerHTML = "";
    processorcoll.forEach(t => {
        document.getElementById('ResultAreAProcessor').innerHTML +=
            "<tr><td>" + t.processorId + "</td><td>"
        + t.name + "</td><td>" + t.maxTurboFrequency + "</td><td>" + `<button type="button" onclick="remove(${t.processorId})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.processorId})">Update</button>` +
            "</td></tr>";
        console.log(t);
    })
}
function showupdate(id) {
    document.getElementById('ProcessorNameToUpdate').value = processorcoll.find(t => t['processorId'] == id)['name'];
    document.getElementById('ProcessorMaxTurboToUpdate').value = processorcoll.find(t => t['processorId'] == id)['maxTurboFrequency'];
    document.getElementById('ProcessorPerformanceCoresToUpdate').value = processorcoll.find(t => t['processorId'] == id)['performanceCores'];
    document.getElementById('ProcessorTotalThreadsToUpdate').value = processorcoll.find(t => t['processorId'] == id)['totalThreads'];
    document.getElementById('BrandIdToUpdate').value = processorcoll.find(t => t['processorId'] == id)['brandId'];
    document.getElementById('ChipsetIdToUpdate').value = processorcoll.find(t => t['processorId'] == id)['chipsetId'];
    document.getElementById('ProcessorUpdateFormDiv').style.display = "flex";
    processorIdToUpdate = id;
}
function update() {
    document.getElementById('ProcessorUpdateFormDiv').style.display = "none";
    let namen = document.getElementById('ProcessorNameToUpdate').value;
    let maxtur = document.getElementById('ProcessorMaxTurboToUpdate').value;
    let perf = document.getElementById('ProcessorPerformanceCoresToUpdate').value;
    let threads = document.getElementById('ProcessorTotalThreadsToUpdate').value;
    let brandI = document.getElementById('BrandIdToUpdate').value;
    let chipsetI = document.getElementById('ChipsetIdToUpdate').value;
    fetch('http://localhost:25922/Processor', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                name: namen,
                maxTurboFrequency: maxtur,
                performanceCores: perf,
                totalThreads: threads,
                brandId: brandI,
                chipsetId: chipsetI,
                processorId: processorIdToUpdate,
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
    fetch('http://localhost:25922/Processor' + id, {
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
    let namen = document.getElementById('ProcessorName').value;
    let maxtur = document.getElementById('ProcessorMaxTurboFreq').value;
    let perf = document.getElementById('ProcessorPerformanceCores').value;
    let threads = document.getElementById('ProcessorTotalThreads').value;
    let brandI = document.getElementById('BrandId').value;
    let chipsetI = document.getElementById('ChipsetId').value;
    fetch('http://localhost:25922/Processor', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                name: namen,
                maxTurboFrequency: maxtur,
                performanceCores: perf,
                totalThreads: threads,
                brandId: brandI,
                chipsetId: chipsetI,
                
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