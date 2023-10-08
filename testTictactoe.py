import tictactoe as ttt;
import unittest;

def test_LetterToNumber():
    assert ttt.letterToNumber("a") == 0;
    assert ttt.letterToNumber("b") == 1;
    assert ttt.letterToNumber("c") == 2;

test_LetterToNumber();