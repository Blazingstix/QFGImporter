Partial Class CharGeneric
    Public Shared Function getBit(inputByte As Byte, bit As Byte) As Boolean
        If bit > 7 Then
            Return 0
        End If
        Dim mask As Byte = 1 << bit

        Return inputByte And mask
    End Function

    Public Shared Function toggleBit(inputByte As Byte, bit As Byte) As Byte
        If bit > 7 Then
            Return inputByte
        End If
        Dim mask As Byte = 1 << bit
        Return inputByte Xor mask
    End Function

    Public Shared Function setBit(inputByte As Byte, bit As Byte, value As Boolean) As Byte
        If bit > 7 Then
            Return inputByte
        End If
        Dim mask As Byte = 1 << bit
        If value Then
            Return inputByte Or mask
        Else
            Return inputByte And (&HFF Xor mask)
        End If
    End Function

    Public Shared Function BitShift(byteArray As Byte(), bits As SByte) As Byte()
        Dim result(byteArray.Length - 1) As Byte
        If bits = 0 Then
            Return byteArray
        ElseIf bits > 0 And bits < 8 Then
            For i As Integer = 0 To byteArray.Length - 2
                result(i) = (byteArray(i) << bits) Or (byteArray(i + 1) >> (8 - bits))
            Next
            result(byteArray.Length - 1) = (byteArray(byteArray.Length - 1) << bits)
        ElseIf bits = 8 Then
            For i As Integer = 0 To byteArray.Length - 2
                result(i) = byteArray(i + 1)
            Next
        ElseIf bits > 8 And bits < 16 Then
            bits = bits Mod 8
            For i As Integer = 0 To byteArray.Length - 3
                result(i) = (byteArray(i + 1) << bits) Or (byteArray(i + 2) >> (8 - bits))
            Next
            result(byteArray.Length - 2) = (byteArray(byteArray.Length - 2) << bits)
        ElseIf bits < 0 And bits > -8 Then

        ElseIf bits = -8 Then
            For i As Integer = 1 To byteArray.Length - 1
                result(i) = byteArray(i - 1)
            Next
        ElseIf bits < -8 And bits > -16 Then

        End If
        Return result
    End Function

    ''' <summary>
    ''' This is used for QFG1 and QFG2
    ''' </summary>
    ''' <param name="hexString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function convertHexStringToByteArray(hexString As String) As Byte()
        Debug.Print(hexString)

        Dim upperBound As Integer = Math.Ceiling(hexString.Length / 2)
        Dim buffer(upperBound - 1) As Byte

        For i As Integer = 0 To upperBound - 1
            Dim indexInString As Integer = i * 2
            Dim tempHex As String = String.Empty
            If indexInString < hexString.Length - 1 Then
                tempHex = hexString.Substring(indexInString, 2).Trim()
            Else
                'NOTE: In QFG3/4, overflow errors can cause the data string to be unexpectedly long.
                '   At some point, I will attempt to read this properly, but until then if we are 
                '   one character short for a full byte we add a 0 to the end of the last character.
                Debug.Print("ERROR: OVERFLOW CORRECTION")
                tempHex = hexString.Substring(indexInString, 1).Trim & "0"
            End If
            buffer(i) = Convert.ToByte(tempHex, 16)
        Next

        'for debug purposes, we'll print out the binary array (with spaces)
        Debug.Print(CharGeneric.BytesToString(buffer))

        Return buffer
    End Function

    ''' <summary>
    ''' This is used for QFG3/4.
    ''' It is a custom two-byte word conversion, for QFG3/4.
    ''' AA BB = (AA*100)+BB
    ''' </summary>
    ''' <param name="hexString"></param>
    ''' <returns></returns>
    ''' <remarks>Does not work if there are errors/overage in the SAV file</remarks>
    Public Shared Function convertHexStringToShortArray(hexString As String) As Short()
        'TODO: Some day, we need to account for data length overflow errors.
        Dim byteArray() As Byte = CharGeneric.convertHexStringToByteArray(hexString)
        Dim upperBound As Integer = Math.Ceiling(byteArray.Length / 2)

        Dim buffer(upperBound - 1) As Short
        For i As Integer = 0 To byteArray.Length - 1 Step 2
            Dim val As Short = byteArray(i) * 100 + byteArray(i + 1)
            buffer(i / 2) = val
        Next

        'for debug purposes, we'll print out the binary array (with spaces)
        Debug.Print(CharGeneric.BytesToString(buffer))

        Return buffer
    End Function


    Public Shared Function importHexStringX2(hexString As String, expectedSize As Integer) As Short()
        'TODO: This function is hard-coded for QFG3... we need to generalize it to support QFG4 too.
        Debug.Print("expectedSize Length: " & expectedSize & "; actual size: " & hexString.Length & vbCrLf & "Difference of " & hexString.Length - expectedSize & " characters.")

        Debug.Print(hexString)
        Dim overflowSize As Integer = hexString.Length - expectedSize
        Dim overflowLeft As Integer = overflowSize
        Dim upperBound As Integer = expectedSize / 4
        Dim buffer(upperBound - 1) As Short
        Dim POS_EXPERIENCE As Integer = 19
        Dim POS_CHECKSUM2 As Integer = upperBound - 5


        Dim curValue As Integer = 0
        Dim curPosition As Integer = 0

        'load the first set of values... these are the ones that are most likely to not be corrupted
        Do Until curValue >= POS_EXPERIENCE
            If curValue < POS_EXPERIENCE Or overflowLeft = 0 Then ' me.offsetexperience
                Dim high As String = hexString.Substring(curPosition, 2).Replace(" ", "0")
                Dim low As String = hexString.Substring(curPosition + 2, 2).Replace(" ", "0")
                Dim hiInt As Integer = Convert.ToByte(high, 16) * 100
                Dim loInt As Integer = Convert.ToByte(low, 16)
                Dim value As Integer = 0
                If hiInt >= 0 Then
                    value = hiInt + loInt
                Else
                    value = hiInt - loInt
                End If

                buffer(curValue) = value
                curPosition += 4
            End If
            curValue += 1
        Loop

        Debug.Print(hexString.Substring(curPosition))

        Dim overChar As Integer = 0
        If overflowSize = 0 Then
            Do Until curPosition >= hexString.Length
                overChar = 0
                Dim high As String = hexString.Substring(curPosition, 2 + overChar).Replace(" ", "0")
                Dim low As String = hexString.Substring(curPosition + 2 + overChar, 2).Replace(" ", "0")
                Dim hiInt As Integer = Convert.ToInt16(high, 16) * 100
                Dim loInt As Integer = Convert.ToByte(low, 16)
                Dim value As Integer = 0
                If hiInt >= 0 Then
                    value = hiInt + loInt
                Else
                    value = hiInt - loInt
                End If
                buffer(curValue) = value And Short.MaxValue
                curPosition += 4 + overChar
                curValue += 1
            Loop
        ElseIf overflowSize = 1 Then
            Do Until curPosition >= hexString.Length
                If curValue = POS_CHECKSUM2 Then
                    overChar = 1
                Else
                    overChar = 0
                End If
                Dim high As String = hexString.Substring(curPosition, 2 + overChar).Replace(" ", "0")
                Dim low As String = hexString.Substring(curPosition + 2 + overChar, 2).Replace(" ", "0")
                Dim hiInt As Integer = Convert.ToInt16(high, 16) * 100
                Dim loInt As Integer = Convert.ToByte(low, 16)
                Dim value As Integer = 0
                If hiInt >= 0 Then
                    value = hiInt + loInt
                Else
                    value = hiInt - loInt
                End If
                buffer(curValue) = value And Short.MaxValue
                curPosition += 4 + overChar
                curValue += 1
            Loop
        ElseIf overflowSize = 28 Then
            Do Until curPosition >= hexString.Length
                If curValue < POS_CHECKSUM2 Then
                    overChar = 1
                Else
                    overChar = 0
                End If
                Dim high As String = hexString.Substring(curPosition, 2 + overChar).Replace(" ", "0")
                Dim low As String = hexString.Substring(curPosition + 2 + overChar, 2).Replace(" ", "0")
                Dim hiInt As Integer = Convert.ToInt16(high, 16) * 100
                Dim loInt As Integer = Convert.ToByte(low, 16)
                Dim value As Integer = 0
                If hiInt >= 0 Then
                    value = hiInt + loInt
                Else
                    value = hiInt - loInt
                End If
                buffer(curValue) = value And Short.MaxValue
                curPosition += 4 + overChar
                curValue += 1
            Loop
        ElseIf overflowSize = 38 Then
            Do Until curValue = POS_CHECKSUM2 + 1
                overChar = 1
                Dim high As String = hexString.Substring(curPosition, 2 + overChar).Replace(" ", "0")
                Dim low As String = hexString.Substring(curPosition + 2 + overChar, 2).Replace(" ", "0")
                Dim hiInt As Integer = Convert.ToInt16(high, 16) * 100
                Dim loInt As Integer = Convert.ToByte(low, 16)
                Dim value As Integer = 0
                If hiInt >= 0 Then
                    value = hiInt + loInt
                Else
                    value = hiInt - loInt
                End If
                buffer(curValue) = value And Short.MaxValue
                curPosition += 4 + overChar
                curValue += 1
            Loop
            'manually set the final bits to their expected values (or 0 in this case).
            buffer(48) = 0
            buffer(49) = 0
            buffer(50) = 0
            buffer(51) = 0
        ElseIf overflowSize = 56 Or overflowSize = 61 Then
            'TODO: these values are not correct after experience. Perhaps if I overflow the experience value to a negative, it will work better.
            Do Until curValue = POS_CHECKSUM2 + 1
                overChar = 2
                Dim high As String = hexString.Substring(curPosition, 2 + overChar).Replace(" ", "0")
                Dim low As String = hexString.Substring(curPosition + 2 + overChar, 2).Replace(" ", "0")
                Dim hiSht As Short = Convert.ToInt16(high, 16)
                Dim hiInt As Integer = Convert.ToInt16(high, 16) * 100
                Dim loInt As Integer = Convert.ToByte(low, 16)
                Dim value As Integer = 0
                If hiInt >= 0 Then
                    value = hiInt + loInt
                Else
                    value = hiInt - loInt
                End If

                'simulate overflow loop-around
                'Dim tmpVal As Integer = 0
                'If value > Short.MaxValue Then
                '    For i As Integer = 0 To value - 1
                '        If tmpVal = Short.MaxValue Then
                '            tmpVal = Short.MinValue
                '        Else
                '            tmpVal += 1
                '        End If
                '    Next
                '    value = tmpVal
                'End If
                'Dim tmpVal As Integer = 0
                'If value > Short.MaxValue Then
                '    tmpVal = value And Short.MaxValue
                '    value = tmpVal
                'End If
                If curValue = 19 Then
                    value = value And Short.MaxValue
                    value += 100
                End If
                buffer(curValue) = value And Short.MaxValue
                curPosition += 4 + overChar
                curValue += 1
            Loop
            'manually set the final bits to their expected values (or 0 in this case).
            buffer(48) = 0
            buffer(49) = 0
            buffer(50) = 0
            buffer(51) = 0
        Else
            MessageBox.Show("Unhandled Overflow Size: " & overflowSize)
        End If

        'for debug purposes, we'll print out the binary array (with spaces)
        Debug.Print(CharGeneric.BytesToString(buffer))

        Return buffer
    End Function

    Public Shared Function importHexStringX(hexString As String, expectedSize As Integer) As Short()
        'TODO: This function is hard-coded for QFG3... we need to generalize it to support QFG4 too.
        Debug.Print("expectedSize Length: " & expectedSize & "; actual size: " & hexString.Length & vbCrLf & "Difference of " & hexString.Length - expectedSize & " characters.")

        Debug.Print(hexString)
        Dim overflowSize As Integer = hexString.Length - expectedSize
        Dim upperBound As Integer = expectedSize / 4
        Dim buffer(upperBound - 1) As Short
        Dim QFG3 As Boolean = (expectedSize = 208)
        Dim QFG4 As Boolean = (expectedSize = 240)

        Dim POS_EXPERIENCE As Integer = 19
        If QFG4 Then
            POS_EXPERIENCE = 20
        End If
        Dim POS_CHECKSUM1 As Integer = upperBound - 6

        Dim curValue As Integer = 0
        Dim curPosition As Integer = 0

        'load the first set of values... these are the ones that are most likely to not be corrupted
        Do Until curValue >= upperBound
            Dim overChar As Integer = 0
            Dim skipLastFour As Boolean = False
            If overflowSize = 0 Then ' me.offsetexperience
                overChar = 0
            ElseIf curValue < POS_EXPERIENCE Then
                'There's no likelyhood of an overflow before we reach experience
                overChar = 0
            ElseIf overflowSize = 1 Then
                'QFG3 (only the 2nd checksum has overflowed)... don't know why that doesn't effect the constants...
                If curValue = POS_CHECKSUM1 + 1 Then
                    overChar = 1
                End If
            ElseIf overflowSize = 6 Then
                'QFG4 (both checksums have overflowed... and the 4 constants after)
                If curValue >= POS_CHECKSUM1 Then
                    overChar = 1
                End If
            ElseIf overflowSize = 28 Then
                'QFG3
                If curValue < POS_CHECKSUM1 + 1 Then
                    overChar = 1
                End If
            ElseIf overflowSize = 34 Then
                'QFG4 (weird one... Experience is too large but the magic spell at 0x42 has no overflow, then 43 resumes with overflow, and then checksum2 to EOF has no overflow)
                If curValue >= POS_EXPERIENCE And curValue <> 42 And curValue <= 54 Then
                    overChar = 1
                End If
            ElseIf overflowSize = 38 Then
                'QFG3
                If curValue >= POS_EXPERIENCE Then
                    overChar = 1
                    skipLastFour = True
                End If
            ElseIf overflowSize = 56 Or overflowSize = 61 Then
                'QFG3 (large overflow... by 2 extra characters in each value)
                If curValue >= POS_EXPERIENCE Then
                    overChar = 2
                    skipLastFour = True
                End If
            ElseIf overflowSize = 204 Then
                If curValue >= POS_EXPERIENCE And POS_CHECKSUM1 > curValue Then
                    overChar = 6
                End If
            ElseIf overflowSize = 210 Then
                If curValue >= POS_EXPERIENCE And POS_CHECKSUM1 > curValue Then
                    overChar = 6
                ElseIf curValue >= POS_CHECKSUM1 Then
                    overChar = 1
                End If
            ElseIf overflowSize = 240 Then
                If curValue >= POS_EXPERIENCE Then
                    overChar = 6
                End If
            Else
                Dim game As String = String.Empty
                If QFG3 Then
                    game = "QFG3"
                ElseIf QFG4 Then
                    game = "QFG4"
                Else
                    game = "(Unknown Game)"
                End If
                If curValue = POS_EXPERIENCE Then
                    MessageBox.Show("This character export file suffers from overflow errors that have not been accounted for by this program." & vbCrLf & vbCrLf & game & " overflow of " & overflowSize & " characters.", "Unhandled overflow size.")
                End If
            End If

                If skipLastFour And curValue >= upperBound - 4 Then
                    buffer(curValue) = 0
                Else
                    Dim high As String = hexString.Substring(curPosition, 2 + overChar).Replace(" ", "0")
                    Dim low As String = hexString.Substring(curPosition + 2 + overChar, 2).Replace(" ", "0")
                Dim hiInt As Integer = 0
                If overChar <= 2 Then
                    hiInt = Convert.ToInt16(high, 16) * 100
                Else
                    hiInt = Convert.ToInt32(high, 16) * 100
                End If
                Dim loInt As Integer = Convert.ToByte(low, 16)
                    Dim value As Integer = 0
                    If hiInt >= 0 Then
                        value = hiInt + loInt
                    Else
                        value = hiInt - loInt
                    End If

                    buffer(curValue) = value And Short.MaxValue
                End If

                curPosition += 4 + overChar
                curValue += 1
        Loop

        If curPosition < hexString.Length - 1 Then
            Debug.Print(hexString.Substring(curPosition))
        End If


        'Else
        'MessageBox.Show("Unhandled Overflow Size: " & overflowSize)
        'End If

        'for debug purposes, we'll print out the binary array (with spaces)
        Debug.Print(CharGeneric.BytesToString(buffer))

        Return buffer
    End Function


    ''' <summary>
    ''' The main method of encription that QFG1/2 saved characters use
    ''' </summary>
    ''' <param name="encodedData"></param>
    ''' <param name="initialCipher"></param>
    ''' <param name="Limiter"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DecodeBytesXor(encodedData As Byte(), initialCipher As Byte, Optional Limiter As Byte = Byte.MaxValue) As Byte()
        Dim decodedValues(encodedData.Length - 1) As Byte

        For i As Integer = 0 To encodedData.Length - 1
            Dim cipher As Byte
            If i = 0 Then
                cipher = initialCipher
            Else
                cipher = encodedData(i - 1) And Limiter
            End If

            decodedValues(i) = encodedData(i) Xor cipher
        Next

        Debug.Print(CharGeneric.BytesToString(decodedValues))
        Debug.Print(CharGeneric.BytesToString(decodedValues, False))
        Return decodedValues
    End Function

    Public Shared Function DecodeBytesXor(encodedData As Short(), initialCipher As Short, Optional Limiter As Short = Short.MaxValue) As Short()
        Dim decodedValues(encodedData.Length - 1) As Short

        For i As Integer = 0 To encodedData.Length - 1
            Dim cipher As Short
            If i = 0 Then
                cipher = initialCipher
            Else
                cipher = encodedData(i - 1) And Limiter
            End If

            decodedValues(i) = encodedData(i) Xor cipher
        Next

        Debug.Print(CharGeneric.BytesToString(decodedValues))
        Debug.Print(CharGeneric.BytesToString(decodedValues, False))
        Return decodedValues
    End Function


    Public Shared Function EncodeBytesXor(decodedValues As Byte(), initialCipher As Byte, Optional Limiter As Byte = Byte.MaxValue) As Byte()
        Dim encodedData(decodedValues.Length - 1) As Byte

        For i As Integer = 0 To decodedValues.Length - 1
            Dim cipher As Byte
            If i = 0 Then
                cipher = initialCipher
            Else
                ' use the previously (just) encoded value as a cipher for the next value to encode
                cipher = encodedData(i - 1) And Limiter
            End If

            encodedData(i) = decodedValues(i) Xor cipher
        Next

        Return encodedData
    End Function

    Public Shared Function EncodeBytesXor(decodedValues As Short(), initialCipher As Short, Optional Limiter As Short = Short.MaxValue) As Short()
        Dim encodedData(decodedValues.Length - 1) As Short

        For i As Integer = 0 To decodedValues.Length - 1
            Dim cipher As Short
            If i = 0 Then
                cipher = initialCipher
            Else
                ' use the previously (just) encoded value as a cipher for the next value to encode
                cipher = encodedData(i - 1) And Limiter
            End If

            encodedData(i) = decodedValues(i) Xor cipher
        Next

        Return encodedData
    End Function

    Public Shared Function BytesToString(byteArray As Byte(), Optional hex As Boolean = True) As String
        Dim values As String = String.Empty
        For Each i As Integer In byteArray
            Dim tmpStr As String = String.Empty
            If hex Then
                tmpStr = i.ToString("X2")
            Else
                tmpStr = i.ToString
            End If

            values &= tmpStr & " "
        Next
        Return values.Trim
    End Function

    Public Shared Function BytesToString(shortArray As Short(), Optional hex As Boolean = True) As String
        Dim values As String = String.Empty
        If shortArray IsNot Nothing Then
            For Each i As Integer In shortArray
                Dim tmpStr As String = String.Empty
                If hex Then
                    tmpStr = i.ToString("X4")
                Else
                    tmpStr = i.ToString
                End If
                values &= tmpStr & " "
            Next
        End If
        Return values.Trim
    End Function

    Public Shared Function ReplaceLeadingZeros(input As String) As String
        Dim output As String = String.Empty
        If input.StartsWith("0") Then
            output = " " & input.Substring(1)
        Else
            output = input
        End If
        Return output
    End Function

End Class

