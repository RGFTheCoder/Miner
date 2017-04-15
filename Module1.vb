Imports System.Media

Module Module1
    Function Draw(PlayerX As Integer, PlayerY As Integer, key As Integer, Debug As Boolean, Color As ConsoleColor, Map(,) As Integer, OldPlrX As Integer, OldPlrY As Integer, Seed As String)
        Console.BackgroundColor = ConsoleColor.DarkCyan
        'Console.Clear()

        'map
        'For y = 0 To 29
        Console.SetCursorPosition(OldPlrX, OldPlrY)
        'For x = 0 To 119
        'Console.SetCursorPosition(x, y)
        'If Map(x, y) = 0 Then
        'Console.BackgroundColor = ConsoleColor.Black
        'Console.ForegroundColor = ConsoleColor.Black
        'ElseIf Map(x, y) <= 69 Then
        'Console.BackgroundColor = ConsoleColor.DarkGray
        'Console.ForegroundColor = ConsoleColor.DarkGray
        'ElseIf Map(x, y) <= 81 Then
        'Console.BackgroundColor = ConsoleColor.Gray
        'Console.ForegroundColor = ConsoleColor.Gray
        'ElseIf Map(x, y) <= 88 Then
        'Console.BackgroundColor = ConsoleColor.White
        'Console.ForegroundColor = ConsoleColor.White
        'ElseIf Map(x, y) <= 93 Then
        'Console.BackgroundColor = ConsoleColor.Yellow
        'Console.ForegroundColor = ConsoleColor.Yellow
        'ElseIf Map(x, y) <= 96 Then
        'Console.BackgroundColor = ConsoleColor.Cyan
        'Console.ForegroundColor = ConsoleColor.Cyan
        'ElseIf Map(x, y) <= 98 Then
        'Console.BackgroundColor = ConsoleColor.Yellow
        'Console.ForegroundColor = ConsoleColor.Yellow
        'ElseIf Map(x, y) <= 99 Then
        'Console.BackgroundColor = ConsoleColor.Green
        'Console.ForegroundColor = ConsoleColor.Green
        'ElseIf Map(x, y) <= 100 Then
        'Console.BackgroundColor = ConsoleColor.Magenta
        'Console.ForegroundColor = ConsoleColor.Magenta
        'End If
        For x = -1 To 1
            For y = -1 To 1
                Console.SetCursorPosition(PlayerX + x, PlayerY + y)
                Console.BackgroundColor = Map(PlayerX + x, PlayerY + y)
                Console.ForegroundColor = Map(PlayerX + x, PlayerY + y)
                Console.Write("#")
            Next
        Next
        'Next
        ' Next

        'player
        Console.SetCursorPosition(PlayerX, PlayerY)
        Console.BackgroundColor = Color
        Console.ForegroundColor = Color
        Console.WriteLine("P")
        Console.SetCursorPosition(0, 0)

        'debug
        If Debug Then
            Console.BackgroundColor = ConsoleColor.Black
            Console.ForegroundColor = ConsoleColor.White
            Console.WriteLine("Key:" & key)
            Console.WriteLine("Width:" & Console.WindowWidth)
            Console.WriteLine("Height:" & Console.WindowHeight)
            Console.WriteLine("X:" & PlayerX)
            Console.WriteLine("Y:" & PlayerY)
            Console.WriteLine("Seed:" & Seed)

            'Console.WriteLine("FPS:" & )

        End If

    End Function
    Function Genmap(seed As String) As Integer(,)
        Console.Clear()
        Randomize(seed)
        Dim map(120, 30) As Integer
        For x = 0 To 120
            For y = 0 To 30
                Dim tile = Rnd(seed) * 100



                If tile = 0 Then
                    map(x, y) = 0 'hole
                ElseIf tile <= 83.5 Then
                    map(x, y) = 8 'stone
                ElseIf tile <= 90.5 Then
                    map(x, y) = 7 'iron
                ElseIf tile <= 94.5 Then
                    map(x, y) = 15 'pearl
                ElseIf tile <= 96.5 Then
                    map(x, y) = 14 'gold
                ElseIf tile <= 98 Then
                    map(x, y) = 11 'Diamond
                ElseIf tile <= 99 Then
                    map(x, y) = 6 'Yellorium
                ElseIf tile <= 99.5 Then
                    map(x, y) = 10 'Uranium
                ElseIf tile <= 100 Then
                    map(x, y) = 13 'Minerium
                End If

            Next
        Next

        Return map
    End Function
    Function DisplayStats(PickLevel As Integer, Stone As Integer, Iron As Integer, Pearl As Integer, Gold As Integer, Diamond As Integer, Yellorium As Integer, Uranium As Integer, Minerium As Integer)
        Console.BackgroundColor = ConsoleColor.Black
        If PickLevel = 1 Then
            Console.ForegroundColor = 8

        ElseIf PickLevel = 2 Then
            Console.ForegroundColor = 7

        ElseIf PickLevel = 3 Then
            Console.ForegroundColor = 15

        ElseIf PickLevel = 4 Then
            Console.ForegroundColor = 14

        ElseIf PickLevel = 5 Then
            Console.ForegroundColor = 11

        ElseIf PickLevel = 6 Then
            Console.ForegroundColor = 6

        ElseIf PickLevel = 7 Then
            Console.ForegroundColor = 10

        ElseIf PickLevel = 8 Then
            Console.ForegroundColor = 13

        End If

        Console.SetCursorPosition(133, 5)
        Console.Write("Pick Level: {0}", PickLevel)

        Console.ForegroundColor = 8
        Console.SetCursorPosition(133, 9)
        Console.Write("Stone: {0}   ", Stone)

        Console.ForegroundColor = 7
        Console.SetCursorPosition(133, 11)
        Console.Write("Iron: {0}  ", Iron)

        Console.ForegroundColor = 15
        Console.SetCursorPosition(133, 13)
        Console.Write("Pearl: {0}  ", Pearl)

        Console.ForegroundColor = 14
        Console.SetCursorPosition(133, 15)
        Console.Write("Gold: {0}  ", Gold)

        Console.ForegroundColor = 11
        Console.SetCursorPosition(133, 17)
        Console.Write("Diamond: {0}  ", Diamond)

        Console.ForegroundColor = 6
        Console.SetCursorPosition(133, 19)
        Console.Write("Yellorium: {0}  ", Yellorium)

        Console.ForegroundColor = 10
        Console.SetCursorPosition(133, 21)
        Console.Write("Uranium: {0}  ", Uranium)

        Console.ForegroundColor = 13
        Console.SetCursorPosition(133, 23)
        Console.Write("Minerium: {0}  ", Minerium)


    End Function
    Sub Main()
        Dim player As SoundPlayer = New SoundPlayer
        player.SoundLocation = "E:\VB.NET Projects\Miner\Miner\Music.wav"
        player.PlayLooping()
        'screen 120x30
        Console.BackgroundColor = ConsoleColor.Black
        Console.ForegroundColor = ConsoleColor.White
        Console.Clear()
        Dim XSize = 160
        Dim YSize = 30
        Console.SetWindowSize(XSize - 0, YSize - 0)
        Console.SetBufferSize(XSize, YSize)
        Console.WriteLine("Enter Seed:")
        Dim seed As String = Console.Read()
        Dim map(,) As Integer = Genmap(seed)
        Dim PlayerX As Integer = Console.WindowWidth / 2
        Dim PlayerY As Integer = Console.WindowHeight / 2
        Dim OldPlayerX As Integer = Console.WindowWidth / 2
        Dim OldPlayerY As Integer = Console.WindowHeight / 2


        Dim PickLevel As Integer = 1
        Dim Stone As Integer = 0
        Dim Iron As Integer = 0
        Dim Pearl As Integer = 0
        Dim Gold As Integer = 0
        Dim Diamond As Integer = 0
        Dim Yellorium As Integer = 0
        Dim Uranium As Integer = 0
        Dim Minerium As Integer = 0

        Dim key
        Dim Debug As Boolean = False
        'For y = 1 To 28
        'Console.SetCursorPosition(1, y)
        'For x = 1 To 119
        'Console.BackgroundColor = map(x, y)
        'Console.ForegroundColor = map(x, y)
        'Console.Write("#")
        '
        'Next
        'Next
        DisplayStats(PickLevel, Stone, Iron, Pearl, Gold, Diamond, Yellorium, Uranium, Minerium)
        Draw(PlayerX, PlayerY, 0, Debug, ConsoleColor.Red, map, OldPlayerX, OldPlayerY, seed)
        While True
            key = Console.ReadKey().Key
            OldPlayerX = PlayerX
            OldPlayerY = PlayerY
            If key = 39 Then
                If Not PlayerX = Console.WindowWidth - 41 Then
                    PlayerX = PlayerX + 1
                End If
            ElseIf key = 37 Then
                If Not PlayerX = 1 Then
                    PlayerX = PlayerX - 1
                End If
            End If
            If key = 40 Then
                If Not PlayerY = Console.WindowHeight - 2 Then
                    PlayerY = PlayerY + 1
                End If
            ElseIf key = 38 Then ' up
                If Not PlayerY = 1 Then
                    PlayerY = PlayerY - 1
                End If
            End If
            If key = 68 Then
                If Debug Then
                    Debug = False
                    Console.Clear()
                Else
                    Debug = True
                End If
            End If


                If map(PlayerX, PlayerY) = 0 Then 'hole

            ElseIf map(PlayerX, PlayerY) = 8 Then 'stone
                Stone = Stone + 1
                map(PlayerX, PlayerY) = 0
            ElseIf map(PlayerX, PlayerY) = 7 And PickLevel >= 2 Then 'iron
                Iron = Iron + 1
                map(PlayerX, PlayerY) = 0
            ElseIf map(PlayerX, PlayerY) = 15 And PickLevel >= 3 Then 'pearl
                Pearl = Pearl + 1
                map(PlayerX, PlayerY) = 0
            ElseIf map(PlayerX, PlayerY) = 14 And PickLevel >= 4 Then 'Gold*
                Gold = Gold + 1
                map(PlayerX, PlayerY) = 0
            ElseIf map(PlayerX, PlayerY) = 11 And PickLevel >= 5 Then 'Diamond*
                Diamond = Diamond + 1
                map(PlayerX, PlayerY) = 0
            ElseIf map(PlayerX, PlayerY) = 6 And PickLevel >= 6 Then 'Yellorium*
                Yellorium = Yellorium + 1
                map(PlayerX, PlayerY) = 0
            ElseIf map(PlayerX, PlayerY) = 10 And PickLevel >= 7 Then 'Uranium*
                Uranium = Uranium + 1
                map(PlayerX, PlayerY) = 0
            ElseIf map(PlayerX, PlayerY) = 13 And PickLevel >= 8 Then 'Minerium*
                Minerium = Minerium + 1
                map(PlayerX, PlayerY) = 0
            Else
                PlayerX = OldPlayerX
                PlayerY = OldPlayerY
            End If

            If Stone >= 50 And PickLevel = 1 Then
                Stone = Stone - 50
                PickLevel = PickLevel + 1
            ElseIf Iron >= 40 And PickLevel = 2 Then
                Iron = Iron - 40
                PickLevel = PickLevel + 1
            ElseIf Pearl >= 30 And PickLevel = 3 Then
                Pearl = Pearl - 30
                PickLevel = PickLevel + 1
            ElseIf Gold >= 20 And PickLevel = 4 Then
                Gold = Gold - 20
                PickLevel = PickLevel + 1
            ElseIf Diamond >= 10 And PickLevel = 5 Then
                Diamond = Diamond - 10
                PickLevel = PickLevel + 1
            ElseIf Yellorium >= 5 And PickLevel = 6 Then
                Yellorium = Yellorium - 5
                PickLevel = PickLevel + 1
            ElseIf Uranium >= 1 And PickLevel = 7 Then
                Uranium = Uranium - 1
                PickLevel = PickLevel + 1
            End If


            Draw(PlayerX, PlayerY, key, Debug, 12, map, OldPlayerX, OldPlayerY, seed)
            DisplayStats(PickLevel, Stone, Iron, Pearl, Gold, Diamond, Yellorium, Uranium, Minerium)
        End While




    End Sub

End Module
