Namespace Utilities
    Public Class CalcUtility

        Public Shared ADD As String = "Add",
           SUBTRACT As String = "Subtract",
           MULTIPLY As String = "Multiply",
           DIVIDE As String = "Divide"

        Private _value1 As Double
        Private _value2 As Double
        Private _result As Double

        ReadOnly Property result As Double
            Get
                Return _result
            End Get
        End Property


        Property value1 As Double
            Get
                Return _value1
            End Get
            Set(value As Double)
                _value1 = value
            End Set
        End Property

        Property value2 As Double
            Get
                Return _value2
            End Get
            Set(value As Double)
                _value2 = value
            End Set
        End Property

        Sub New(dbl1 As Double, dbl2 As Double)
            value1 = dbl1
            value2 = dbl2
        End Sub

        Public Sub AddValues()
            _result = value1 + value2
        End Sub
        Public Sub SubtractValues()
            _result = value1 - value2
        End Sub
        Public Sub MultiplyValues()
            _result = value1 * value2
        End Sub
        Public Sub DivideValues()
            _result = value1 / value2
        End Sub
    End Class
End Namespace
