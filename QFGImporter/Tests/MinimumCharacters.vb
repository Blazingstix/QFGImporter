﻿Public Class MinimumCharacters
    Public Const QFG2Fighter As String = "535260606325 d317745 33f17171725252525252525252525252525252525252525255c5a 526656d4030"
    Public Const QFG2Wizard As String = "525361616149 f33 1331b1b29292929296f6f6f6f6f476f7171436b59717070707070 9 f7124676f4232"
    Public Const QFG2Thief As String = "515062626a586a2c1e221010221e22102c2c2c2c2c2c2c2c2c2c2c2c2c2c29292929295056193a79715c2c"

    Public Const QFG3Fighter As String = "53515151d0461694 266f072161616727272281a1a1a1a1a1a1a1a1a1a1a1a1a1a1a1a1b1a1b1b1aba84128ba4342d8e"
    Public Const QFG3Wizard As String = "5250505050 096f296f2a2a2c6c6c6c6c650281a1a1a1a1a7e1a284c284c284c284c7e7e7f7e7e7fdfe117cfe07069ca"
    Public Const QFG3Thief As String = "51535353533753c5a1c5a1a1c5a1c5a1c5c5a193939393939393939393939393939393969796969737 990f1de4e57f4"

    Public Const QFG4Fighter As String = " 053 053 053 053 145 061 11c 061 145 053 145 061 061 061 145 145 145 061 145 145 145 145 145 145 145 145 145 145 145 145 145 145 145 145 145 145 145 145 145 145 145 145 145 145 14c 0 e f17 430 5 3 4 a 332 41c"
    Public Const QFG4Wizard As String = " 052 052 052 052 136 060 144 060 144 060 060 144 144 144 144 144 052 14f 117 117 117 117 117 14f 117 14f 117 11d 049 14f 117 225 025 14f 025 025 14f 14f 14f 14f 14f 14f 14f 14f 146 0141927 240 313 326 4 6 338"
    Public Const QFG4Thief As String = " 051 051 051 051 135 051 147 063 147 063 063 11e 04a 11e 04a 11e 11e 04a 214 214 214 214 214 214 214 214 214 214 214 214 214 214 214 214 214 214 214 214 214 214 214 214 214 214 161 117 f1d 1 4 05f 032 22e 0 4"

    Public Const QFG5Fighter As String = " 053 053 053 053 245 021 335 021 245 053 245 053 053 053 353 053 053 353 053 053 053 053 053 053 053 053 053 053 053 053 053 053 053 053 053 053 053 053 053 053 053 053 053 053 053 053 053 053 053 053 053 053 04a 22c16 c264c263b2742281a27 c"
    Public Const QFG5Wizard As String = " 052 052 052 052 144 5 2 212 5 2 212 5 2 5 2 212 212 212 212 212 358 144 358 358 358 358 358 358 352 052 136 052 352 426 136 052 144 060 144 060 060 136 052 052 136 052 136 052 052 052 052 052 052 052 052 052 04b 22d24 4 934 9 b 95e 8 6 950"
    Public Const QFG5Thief As String = " 051 051 051 051 147 35b 211 023 247 023 023 337 04f 337 04f 249 249 03d 163 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 45b 462 3201140275428 7282a2636285c"

    Public Const QFG5Paladin As String = " 050 050 050 050 430 224 33e 02a 23e 058 23e 058 058 058 438 21c 21c 438 132 132 132 132 132 132 132 132 132 132 132 132 132 132 132 132 132 132 132 132 132 132 132 132 132 132 132 132 132 132 132 132 132 132 12b 0311754255c26 f2516243e2548"

    Public Shared Function GetCharacter(game As Enums.Games, [class] As Enums.CharacterClass) As CharGeneric
        Dim newChar As CharGeneric = Nothing
        Select Case game
            Case Enums.Games.QFG1
                newChar = New CharQFG1
                Select Case [class]
                    Case Enums.CharacterClass.Fighter, Enums.CharacterClass.Paladin
                        newChar.LoadData(QFG2Fighter)
                    Case Enums.CharacterClass.Magic
                        newChar.LoadData(QFG2Wizard)
                    Case Enums.CharacterClass.Thief
                        newChar.LoadData(QFG2Thief)
                End Select
            Case Enums.Games.QFG2
                newChar = New CharQFG2
                Select Case [class]
                    Case Enums.CharacterClass.Fighter, Enums.CharacterClass.Paladin
                        newChar.LoadData(QFG3Fighter)
                    Case Enums.CharacterClass.Magic
                        newChar.LoadData(QFG3Wizard)
                    Case Enums.CharacterClass.Thief
                        newChar.LoadData(QFG3Thief)
                End Select
            Case Enums.Games.QFG3
                newChar = New CharQFG3
                Select Case [class]
                    Case Enums.CharacterClass.Fighter, Enums.CharacterClass.Paladin
                        newChar.LoadData(QFG4Fighter)
                    Case Enums.CharacterClass.Magic
                        newChar.LoadData(QFG4Wizard)
                    Case Enums.CharacterClass.Thief
                        newChar.LoadData(QFG4Thief)
                End Select
            Case Enums.Games.QFG4
                newChar = New CharQFG4
                Select Case [class]
                    Case Enums.CharacterClass.Fighter
                        newChar.LoadData(QFG5Fighter)
                    Case Enums.CharacterClass.Magic
                        newChar.LoadData(QFG5Wizard)
                    Case Enums.CharacterClass.Thief
                        newChar.LoadData(QFG5Thief)
                    Case Enums.CharacterClass.Paladin
                        newChar.LoadData(QFG5Paladin)
                End Select
        End Select
        If newChar IsNot Nothing Then
            newChar.Name = "Unknown Hero"
        End If
        Return newChar
    End Function


End Class
