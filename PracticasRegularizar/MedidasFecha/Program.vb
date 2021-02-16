Imports System

Module Program
    Sub Main()
        ingresoDias()

        Console.ReadKey()
    End Sub

    Friend Enum medidasDias
        Semana = 7
        Mes = 30
        Bimestre = 61
        Trimestre = 91
        Cuatrimestre = 122
        Semestre = 183
        Año = 365
    End Enum

    Private Sub ingresoDias()
        Dim inputDias As Object
        Do
            Console.Write("Ingrese una cantidad de días: ")
            inputDias = Console.ReadLine()
        Loop Until validarIngresoDias(inputDias)

        If validarIngresoDias(inputDias) Then
            informarMedicion(inputDias)
        End If
    End Sub

    Private Function validarIngresoDias(inputDias As Object) As Boolean
        ' Trato de parsear el objeto string como un Integer. Si el parse es exitoso, es Integer
        Dim inputDiasINT As Integer
        If Not Integer.TryParse(inputDias, inputDiasINT) Then
            Console.WriteLine("ERROR: el ingreso no corresponde a un número entero.")
            Return False
        ElseIf inputDias <= 0 Then
            Console.WriteLine("ERROR: el ingreso es menor o igual a cero.")
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub informarMedicion(inputDias As UInteger)
        Dim diasRestantes As UInteger = inputDias
        Dim cantDias, cantSema, cantMes, cantBim, cantTri, cantCua, cantSeme, cantAño As UShort
        cantMes = cantBim = cantTri = cantCua = cantSeme = cantAño = cantSema = cantDias = 0
        Do Until diasRestantes = 0
            Select Case diasRestantes
                Case >= medidasDias.Año
                    cantAño = diasRestantes \ medidasDias.Año
                    diasRestantes = diasRestantes - (medidasDias.Año * cantAño)
                    Console.WriteLine("{0} AÑOS", cantAño)

                Case medidasDias.Semestre To medidasDias.Año - 1
                    cantSeme = diasRestantes \ medidasDias.Semestre
                    diasRestantes = diasRestantes - (medidasDias.Semestre * cantSeme)
                    Console.WriteLine("{0} SEMESTRES", cantSeme)

                Case medidasDias.Cuatrimestre To medidasDias.Semestre - 1
                    cantCua = diasRestantes \ medidasDias.Cuatrimestre
                    diasRestantes = diasRestantes - (medidasDias.Cuatrimestre * cantCua)
                    Console.WriteLine("{0} CUATRIMESTRES", cantCua)

                Case medidasDias.Trimestre To medidasDias.Cuatrimestre - 1
                    cantTri = diasRestantes \ medidasDias.Trimestre
                    diasRestantes = diasRestantes - (medidasDias.Trimestre * cantTri)
                    Console.WriteLine("{0} TRIMESTRES", cantTri)

                Case medidasDias.Bimestre To medidasDias.Trimestre - 1
                    cantBim = diasRestantes \ medidasDias.Bimestre
                    diasRestantes = diasRestantes - (medidasDias.Bimestre * cantBim)
                    Console.WriteLine("{0} BIMESTRES", cantBim)

                Case medidasDias.Mes To medidasDias.Bimestre - 1
                    cantMes = diasRestantes \ medidasDias.Mes
                    diasRestantes = diasRestantes - (medidasDias.Mes * cantMes)
                    Console.WriteLine("{0} MESES", cantMes)
                Case medidasDias.Semana To medidasDias.Mes - 1
                    cantSema = diasRestantes \ medidasDias.Semana
                    diasRestantes = diasRestantes - (medidasDias.Semana * cantMes)
                    Console.WriteLine("{0} MESES", cantSema)
                Case < medidasDias.Semana
                    Console.WriteLine("{0} DIAS", diasRestantes)
                    diasRestantes -= diasRestantes
            End Select
        Loop
    End Sub
End Module

