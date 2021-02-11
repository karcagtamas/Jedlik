function ellsz()
{
    var a = document.getElementById("row").value;
    var b = document.getElementById("col").value;
    if (a != null)
    {
        if (a < 0) a = 0;
    }
    else
    {
        a = 0;
    }
    if (a != null)
    {
        if (b < 0) b = 0;
    }
    else
    {
        b = 0;
    }
    

    document.getElementById("row").value = a;
    document.getElementById("col").value = b;
}
function elld()
{
    var a = document.getElementById("start").value;
    var b = document.getElementById("end").value;
    if (a >= b)
    {
        document.getElementById("start").value = b - 1;
        document.getElementById("end").value;
        document.getElementById("notf").innerHTML = "Nem megfelelő intervallum! Visszaállítottuk alapértelmezettre!";
    }
}
function gen()
{
    var a = document.getElementById("row").value;
    var b = document.getElementById("col").value;
    var start = document.getElementById("start").value;
    var end = document.getElementById("end").value;
    var row;
    
    var tab = document.getElementById("táblázat");
    tab.innerHTML = '';
    for (var j = 0; j < a; j++)
    {
        row = tab.insertRow(0);
        for (var i = 0; i < b; i++) {
            var col = row.insertCell(0);
            var x = (Math.random() * (end - start + 1)) + start;
            col.innerHTML = x;
        }
    }
    
}