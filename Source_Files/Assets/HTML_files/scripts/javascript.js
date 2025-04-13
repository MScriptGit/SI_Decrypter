//Made by MScript 2024
function tableGen() {
    
    //get the userInput
    const userInput = document.getElementById("userInput").value;
    
    //convert string to all uppercase
    const allCaps = userInput.toUpperCase();
    
    //remove all chars except letters and commas
    const cleanInput = allCaps.replace(/[^A-Z\\,]/g, "");
    
    //put words into array
    const toArray = cleanInput.split(",");
    
    //get width of table
    const wordLen = toArray[0].length;
    
    //get number of rows
    const numOfRows = toArray.length;
    
    //generate table
    let tableStr = "";
    let i = 0;
    let upperArrows = "";
    let lowerArrows = "";
    //fill upper row with up arrows
    for (j=0; j<wordLen; j++) {
        let k = j + 1;
        let temp = upperArrows.concat("<td id=\"up" + k + "\" onClick=\"btnClicked(this.getAttribute(\'id\'));\"><img src=\"Arrow.png\" class=\"arrowUp\"></td>");
        upperArrows = temp;
    }
    const topRow = "<tr id=\"upRow\">" + upperArrows + "</tr><tr class=\"rowSpacer\"></tr>";
    //fill lower row with up arrows
    for (j=0; j<wordLen; j++) {
        let k = j + 1;
        let temp = lowerArrows.concat("<td id=\"down" + k + "\" onClick=\"btnClicked(this.getAttribute(\'id\'));\"><img src=\"Arrow.png\" class=\"arrowDown\"></td>");
        lowerArrows = temp;
    }
    const lowerRow = "<tr class=\"rowSpacer\"></tr><tr id=\"downRow\">" + lowerArrows + "</tr>";
    
    //fill tableRow
    while (i<numOfRows) {
        let k = i + 1;
        let temp = tableStr.concat("<tr class=\"row" + k + "\">");
        tableStr = temp;
        let arrayItt = toArray[i];
        let fillRow = "";
        for (j=0; j<wordLen; j++) {
            let letterItt = arrayItt.charAt(j);
            let l = j + 1;
            let rowResult = fillRow.concat("<td class=\"r" + k + " c" + l + "\" id=\"rc" + k +"" + l + "\">" + letterItt + "</td>");
            fillRow = rowResult;
        }
        let result = tableStr.concat(fillRow + "</tr>");
        tableStr = result;
        i++;
    }
    
    let tableComplete = "<table class=\"" + numOfRows + "\" id=\"table\">" + topRow + "" + tableStr + "" + lowerRow + "</table>";
    
    //output
    document.getElementById("output").innerHTML = tableComplete;
    
    
    //return false to prevent form to force page reload
    return false;
}

//catch button action
function btnClicked(id) {
    let colNum = id.slice(-1);
    const numOfRows = document.getElementById("table").className;
    
    //select up or down buttons
    switch(id.slice(0, 2)) {
        case "up":
            const colToArray = [];
            for (i=1; i<=numOfRows; i++) {
                let tdVal = document.getElementById("rc" + i + "" + colNum).textContent;
                colToArray.push(tdVal);
            }
            const arrayLen = colToArray.length;
            for (j=0; j<arrayLen; j++) {
                if (j===0) {
                    let k = numOfRows;
                    document.getElementById("rc" + k + "" + colNum).innerHTML = colToArray[j];
                }
                else {
                    document.getElementById("rc" + j + "" + colNum).innerHTML = colToArray[j];
                }
            }
            break;
        case "do":
            const colToArray2 = [];
            for (i=1; i<=numOfRows; i++) {
                let tdVal = document.getElementById("rc" + i + "" + colNum).textContent;
                colToArray2.push(tdVal);
            }
            const arrayLen2 = colToArray2.length;
            for (j=0; j<arrayLen2; j++) {
                let tempNumOfRows = numOfRows - 1;
                if (j==tempNumOfRows) {
                    document.getElementById("rc1" + colNum).innerHTML = colToArray2[j];
                }
                else {
                    let k = j+2;
                    document.getElementById("rc" + k + "" + colNum).innerHTML = colToArray2[j];
                }
            }
            break;
    }
    

//return false to prevent form to force page reload
return false;
}
