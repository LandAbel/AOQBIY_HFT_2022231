function backtomain() {
    window.location = "index.html";
}


let noncrudcoll01 = [];

async function getdata01() {
    await fetch('http://localhost:25922/Statistics/z790ProcessorsWith10Core')
        .then(x => x.json())
        .then(y => {
            noncrudcoll01 = y;
            console.log(noncrudcoll01)
            display01();
        });
}
function display01() {
    document.getElementById('NONCRUD07FORM').style.display = "none";
    document.getElementById('NONCRUD01FORM').style.display = "initial";
    document.getElementById('resultNONCRUD01').innerHTML = "";
    noncrudcoll01.forEach(t => {
        document.getElementById('resultNONCRUD01').innerHTML +=
            "<tr><td>" + t.processorId + "</td><td>"
        + t.name+"</td></tr>";
        console.log(t);
    })
}
async function getdata02() {
    await fetch('http://localhost:25922/Statistics/INTELProcessorsWithMorethan30mbCache')
        .then(x => x.json())
        .then(y => {
            noncrudcoll01 = y;
            console.log(noncrudcoll01)
            display01();
        });
}
function display02() {
    document.getElementById('NONCRUD07FORM').style.display = "none";
    document.getElementById('NONCRUD01FORM').style.display = "initial";
    document.getElementById('resultNONCRUD01').innerHTML = "";
    noncrudcoll01.forEach(t => {
        document.getElementById('resultNONCRUD01').innerHTML +=
            "<tr><td>" + t.processorId + "</td><td>"
            + t.name + "</td></tr>";
        console.log(t);
    })
}
async function getdata03() {
    await fetch('http://localhost:25922/Statistics/INTELProcessorsWithIntegratedGraph')
        .then(x => x.json())
        .then(y => {
            noncrudcoll01 = y;
            console.log(noncrudcoll01)
            display01();
        });
}
function display03() {
    document.getElementById('NONCRUD07FORM').style.display = "none";
    document.getElementById('NONCRUD01FORM').style.display = "initial";
    document.getElementById('resultNONCRUD01').innerHTML = "";
    noncrudcoll01.forEach(t => {
        document.getElementById('resultNONCRUD01').innerHTML +=
            "<tr><td>" + t.processorId + "</td><td>"
            + t.name + "</td></tr>";
        console.log(t);
    })
}
async function getdata04() {
    await fetch('http://localhost:25922/Statistics/MaxTurboFreqMoreThen49ProcessorFromAMD')
        .then(x => x.json())
        .then(y => {
            noncrudcoll01 = y;
            console.log(noncrudcoll01)
            display01();
        });
}
function display04() {
    document.getElementById('NONCRUD07FORM').style.display = "none";
    document.getElementById('NONCRUD01FORM').style.display = "initial";
    document.getElementById('resultNONCRUD01').innerHTML = "";
    noncrudcoll01.forEach(t => {
        document.getElementById('resultNONCRUD01').innerHTML +=
            "<tr><td>" + t.processorId + "</td><td>"
            + t.name + "</td></tr>";
        console.log(t);
    })
}
async function getdata05() {
    await fetch('http://localhost:25922/Statistics/MobileProcessorsWithMoreThan6Core')
        .then(x => x.json())
        .then(y => {
            noncrudcoll01 = y;
            console.log(noncrudcoll01)
            display01();
        });
}
function display05() {
    document.getElementById('NONCRUD07FORM').style.display = "none";
    document.getElementById('NONCRUD01FORM').style.display = "initial";
    document.getElementById('resultNONCRUD01').innerHTML = "";
    noncrudcoll01.forEach(t => {
        document.getElementById('resultNONCRUD01').innerHTML +=
            "<tr><td>" + t.processorId + "</td><td>"
            + t.name + "</td></tr>";
        console.log(t);
    })
}
async function getdata06() {
    await fetch('http://localhost:25922/Statistics/IntelProcessorsWithMoreTh30Threads')
        .then(x => x.json())
        .then(y => {
            noncrudcoll01 = y;
            console.log(noncrudcoll01)
            display01();
        });
}
function display06() {
    document.getElementById('NONCRUD07FORM').style.display = "none";
    document.getElementById('NONCRUD01FORM').style.display = "initial";
    document.getElementById('resultNONCRUD01').innerHTML = "";
    noncrudcoll01.forEach(t => {
        document.getElementById('resultNONCRUD01').innerHTML +=
            "<tr><td>" + t.processorId + "</td><td>"
            + t.name + "</td></tr>";
        console.log(t);
    })
}
async function getdata07() {
    await fetch('http://localhost:25922/Statistics/ProcessorsByBrands')
        .then(x => x.json())
        .then(y => {
            noncrudcoll01 = y;
            console.log(noncrudcoll01)
            display07();
        });
}
function display07() {
    document.getElementById('NONCRUD01FORM').style.display = "none";
    document.getElementById('NONCRUD07FORM').style.display = "initial";
    document.getElementById('resultNONCRUD07').innerHTML = "";
    noncrudcoll01.forEach(t => {
        document.getElementById('resultNONCRUD07').innerHTML +=
            "<tr><td>" + t.brand + "</td><td>" + t.avgCore + "</td><td>"
            + t.number + "</td></tr>";
        console.log(t);
    })
}