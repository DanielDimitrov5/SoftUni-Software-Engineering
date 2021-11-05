function Pies(pies, firstFlavor, secondFlavor){

    let startIndex = pies.indexOf(firstFlavor);
    let endIndex = pies.indexOf(secondFlavor);

    return pies.slice(startIndex, endIndex + 1);
}

console.log(Pies(['Apple Crisp',
'Mississippi Mud Pie',
'Pot Pie',
'Steak and Cheese Pie',
'Butter Chicken Pie',
'Smoked Fish Pie'],
'Pot Pie',
'Smoked Fish Pie'
))