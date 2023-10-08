def printPlayField(playFieldValue):
    y = 0;
    while(y <= 2):
        print("|---|---|---|");
        print("| " + str(playFieldValue[y][0]) + " | " + str(playFieldValue[y][1]) + " | " + str(playFieldValue[y][2]) + " | ");
        y = y + 1;
    print("|---|---|---|");

def letterToNumber(letter):
    if(letter == "a"):
        y = 0;
    if(letter == "b"):
        y = 1;
    if(letter == "c"):
        y = 2;
    return y;

def fieldIsUsed(playFieldValue, fieldF):
    isUsed = False;
    y = letterToNumber(fieldF[0]);
    if(playFieldValue[int(y)][int(fieldF[1])] != " "):
        isUsed = True;
    return isUsed;

def setField(playFieldValue, fieldF, playerF):
    x = int(fieldF[1])
    y = int(letterToNumber(fieldF));
    playFieldValue[y][x] = playerF;
    return playFieldValue;

def checkWin(playFieldValue, playerF):
    horizontalTop = False;
    horizontalMiddle = False;
    horizontalBottom = False;
    verticalLeft = False;
    verticalMiddle = False;
    verticalRight = False;
    diagonal1 = False;
    diagonal2 = False;
    horizontalTop = playFieldValue[0][0] == playerF and playFieldValue[0][1] == playerF and playFieldValue[0][2] == playerF;
    horizontalMiddle = playFieldValue[1][0] == playerF and playFieldValue[1][1] == playerF and playFieldValue[1][2] == playerF;
    horizontalBottom = playFieldValue[2][0] == playerF and playFieldValue[2][1] == playerF and playFieldValue[2][2] == playerF;
    verticalLeft = playFieldValue[0][0] == playerF and playFieldValue[1][0] == playerF and playFieldValue[2][0] == playerF;
    verticalMiddle = playFieldValue[0][1] == playerF and playFieldValue[1][1] == playerF and playFieldValue[2][1] == playerF;
    verticalRight = playFieldValue[0][2] == playerF and playFieldValue[1][2] == playerF and playFieldValue[2][2] == playerF;
    diagonal1 = playFieldValue[0][0] == playerF and playFieldValue[1][1] == playerF and playFieldValue[2][2] == playerF;
    diagonal2 = playFieldValue[0][2] == playerF and playFieldValue[1][1] == playerF and playFieldValue[2][0] == playerF;
    return horizontalTop or horizontalMiddle or horizontalBottom or verticalLeft or verticalMiddle or verticalRight or diagonal1 or diagonal2;

def changePlayer(playerF):
    if(playerF == "O"):
        return "X";
    if(playerF == "X"):
        return "O";

#----------------------------------------------------------------------------

end = False;
zuege = 0;
player = "X";
playField = [[" "," "," "],[" "," "," "],[" "," "," "]];

while(end == False):
    eingabePruefung = False;
    field = "";
    print("Zuege " + str(zuege));
    printPlayField(playField);


    while(eingabePruefung == False):
        field = input("Player " + player + " type in field: ").lower();
        if(field == "a1" or field == "a2" or field == "a3" or field == "b1" or field == "b2" or field == "b3" or field == "c1" or field == "c2" or field == "c3"):
            print("right");
            if(fieldIsUsed(playField, field)):
                print("Das Feld ist belegt");
            elif(fieldIsUsed(playField, field) == False):
                playField = setField(playField, field, player);
                zuege = zuege + 1;
                eingabePruefung = True;
        if(field == "?"):
            print("Help");

    if(checkWin(playField, player) == True and zuege > 4):
        print("Player " + player + " Won.");
        end = True;

    if(zuege <= 9):
        print("unentschieden");
        end = True;
    
    player = changePlayer(player);





