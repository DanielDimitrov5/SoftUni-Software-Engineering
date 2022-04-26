function TicTacToe(coordinates){
    let board = [[false, false, false],
                 [false, false, false],
                 [false, false, false]]


    let turnCounter = 0;

    for (const turn of coordinates) {

        let [x, y] = turn.split(' ')

        let sign = '';

        if (turnCounter % 2 == 0) {
            sign = 'X'
        }
        else{
            sign = 'O'
        }

        let result = MakeTurn(x, y, sign, board);
        if (CheckIfBoardIsFull() && CheckForWinner(board, sign) == false) {
            console.log("The game ended! Nobody wins :(");
            break;
        }


        if (result === false) {
            continue;
        }

        if(turnCounter > 2){

            if (CheckForWinner(board, sign)) {
                console.log(`Player ${sign} wins!`)
                break;
            }
        }
        turnCounter++;
    }
    //Print matrix
    PrintBoard(board)

    function CheckIfBoardIsFull(){
        for (let i = 0; i < 3; i++) {
            for (let j = 0; j < 3; j++) {
                if (board[i][j] === false) {
                    return false
                }
            }            
        }
        return true;
    }

    function MakeTurn(x, y, sign, board){

        if (board[x][y] != false) {
            console.log("This place is already taken. Please choose another!");
    
            return false;
        }
        board[x][y] = sign;
    
        return true;
    }
    function CheckForWinner(board, sign){

        let count = 0
    
        for (let i = 0; i < 3; i++) {
            for (let j = 0; j < 3; j++) {
                if (board[i][j] == sign) {
                    count++;
                }
            }     
            
            if (count == 3) {
                return true;
            }
    
            count = 0;
        }
    
        for (let i = 0; i < 3; i++) {
            for (let j = 0; j < 3; j++) {
                if (board[j][i] == sign) {
                    count++;
                }
            }     
            
            if (count == 3) {
                return true;
            }
    
            count = 0;
        }
    
        for (let i = 0; i < 3; i++) {
            if (board[i][i] == sign) {
                count++;
            }
        }
    
        if (count == 3) {
            return  true;
        }
    
        count = 0;
    
        let x = 0;
        let y = 2 // 3-1
    
        for (let i = 0; i < 3; i++) {
            if (board[y--][x++] == sign) {
                count++;
            }
        }
    
        if (count == 3) {
            return true;
        } 
        
        return false;
    }
    
    
    function PrintBoard(board){
        let output = [];
        
        for (let i = 0; i < 3; i++) {
            let rows = board[i].join('\t');
            
            output.push(rows);
        }
    
        console.log(output.join('\n'))
    }
}


TicTacToe(["0 1",
"0 0",
"0 2",
"2 0",
"1 0",
"1 2",
"1 1",
"2 1",
"2 2",
"0 0"]
)