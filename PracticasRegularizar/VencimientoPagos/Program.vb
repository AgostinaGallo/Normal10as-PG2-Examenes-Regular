Imports System
'Recuperatorio Noviembre
'1. Crear un programa que informe los vencimientos de pagos de un servicio:
'    - Se ingrese una fecha. Verificar que sea una fecha a futuro.
'    - Se ingrese un número entero que representa a una cantidad dada de meses. Verificar que sea mayor a cero y hasta 60.
'    - Mostrar como resultado una lista de fechas, empezando por el mes siguiente y tantas como cantidad de meses ingresados.
'    - Informar también el dia de la semana en palabras en español.
'    - Las fechas en cada uno de los meses siguientes deben corresponder al mismo día ingresado excepto si el día resultante es Sábado o Domingo, en ese caso deberá alterarse para el próximo Lunes.
'    Tiempo: 30 minutos.

Module Program
    Sub Main()
        Dim eleccion As ConsoleKeyInfo
        Dim fechaIngresada As Date
        Dim mesesIngresados As Short
        Do
            Console.Write("Presione cualquier tecla para continuar" & vbCrLf & "ESC = SALIR: ")
            eleccion = Console.ReadKey()
            Console.Clear()
            If eleccion.Key = ConsoleKey.Escape Then
                Console.WriteLine("Adiós!")
                Exit Do
            Else
                ingresoFecha(fechaIngresada)
                ingresoMeses(mesesIngresados)
                informeVencimientos(fechaIngresada, mesesIngresados)
            End If

        Loop While eleccion.Key <> ConsoleKey.Escape
    End Sub

    Private Sub ingresoFecha(ByRef fechaIngresada As Date)
        Do
            Console.Write("Ingrese una fecha (dd/mm/aaaa): ")
            fechaIngresada = Console.ReadLine()
        Loop Until validarIngresoFecha(fechaIngresada)
    End Sub

    Private Function validarIngresoFecha(fechaIngresada As Date) As Boolean
        If fechaIngresada > Date.Today Then
            Return True
        Else
            Console.WriteLine("ERROR: La fecha ingresada es incorrecta.")
            Return False
        End If
    End Function

    Private Sub ingresoMeses(ByRef mesesIngresados As Short)
        Do
            Console.Write("Ingrese una cantidad de meses (hasta 60 máx.): ")
            mesesIngresados = Console.ReadLine()
        Loop Until validarIngresoMeses(mesesIngresados)
    End Sub

    Private Function validarIngresoMeses(mesesIngresados As Short) As Boolean
        If mesesIngresados > 0 And mesesIngresados <= 60 Then
            Return True
        Else
            Console.WriteLine("ERROR: La cantidad ingresada de meses es incorrecta.")
            Return False
        End If
    End Function

    Private Sub informeVencimientos(ByRef fechaIngresada As Date, ByRef mesesIngresados As Short)
        Dim fechaNueva As Date = fechaIngresada
        Console.WriteLine("FECHAS DE VENCIMIENTO")
        For i = 0 To mesesIngresados
            fechaNueva = fechaNueva.AddMonths(1)
            If fechaNueva.DayOfWeek = 6 Or fechaNueva.DayOfWeek = 0 Then
                Console.Write("!Sabado o Domingo, " & fechaNueva.ToShortDateString & " => Convertida a: ")
                Do Until fechaNueva.DayOfWeek = 1
                    fechaNueva = fechaNueva.AddDays(1)
                Loop
                Console.WriteLine(WeekdayName(fechaNueva.DayOfWeek) & ", " & fechaNueva.ToShortDateString)
            Else
                Console.WriteLine(WeekdayName(fechaNueva.DayOfWeek) & ", " & fechaNueva.ToShortDateString)
            End If

        Next
    End Sub
End Module
