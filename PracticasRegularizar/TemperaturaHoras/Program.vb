Imports System
'Recuperatorio Noviembre
'2. Crear un programa que informe a partir de lecturas de un día:
'    - Ingresar un entero que represente una hora. El valor debe estar entre 0 y 23. Solo puede haber una lectura por hora y puede haber horas sin lectura.
'    - Ingresar un flotante que represente la temperatura a la hora especificada previamente. Se esperan valores negativos y positivos entre -50 y 50
'    - Ingresar por lo menos un par de datos. Luego de cada para de datos informar según las consignas a seguir y preguntar si desea ingresar otro par de datos. Si no se ingresan más datos terminar el programa.
'    - Informar todas las lecturas ordenadas por hora.
'    - Informar la temperatura máxima y la hora a la que fue.
'    - Informar la temperatura mínima y la hora a la que fue.
'    - Informar la amplitud máxima de temperatura en el día.
'    - Informar el promedio de temperatura.
'    - Informar la amplitud mínima entre las horas que fue, estas pueden ser varias.
'    Tiempo: 60 minutos.

Sub Main(args As String())
        Dim eleccion As ConsoleKeyInfo
        Dim hora As Byte
        Dim temperatura As Single
        Dim 
        Do While eleccion.Key <> ConsoleKey.Escape

            Console.WriteLine("Presione cualquier tecla para continuar.." & vbCrLf & "ESC = Salir")
            eleccion = Console.ReadKey
        Loop

        Console.Write("Ingrese hora: ")
        hora = Console.ReadLine()


        Console.Write("Ingrese temperatura (-50 hasta 50): ")
        temperatura = Console.ReadLine()

    End Sub

    Private Function validarIngresoHora(ByRef hora As Byte) As Boolean
        If hora >= 0 And hora <= 23 Then
            Return True
        Else
            Return False
        End If
    End Function



    Private Function validarIngresoTemperatura(ByRef temperatura As SByte)
        If temperatura >= -50 And temperatura <= 50 Then
            Return True
        Else
            Return False
        End If
    End Function
End Module
