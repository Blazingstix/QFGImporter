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

End Class

