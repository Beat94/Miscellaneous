import tictactoe as ttt;

print(str(ttt.letterToNumber("c")))

playField = [[" "," "," "],[" "," "," "],[" "," "," "]];

ttt.printPlayField(playField);
print(".")

playfield = ttt.setPlayFieldValue(playField, ttt.letterToNumber("a"), 0, "a");

ttt.printPlayField(playField);

playField = ttt.setField(playField,"b0", "d");