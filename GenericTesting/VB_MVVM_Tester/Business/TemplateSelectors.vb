﻿Public NotInheritable Class TemplateSelectorMain
  Inherits DataTemplateSelector

  Public Property MainTemplate As DataTemplate
  Public Property OtherTemplate As DataTemplate

  Public Overrides Function SelectTemplate(item As Object, container As DependencyObject) As DataTemplate
    If TypeOf item Is Stuff Then
      Return If(TryCast(item, Stuff).ShipType = ShipType.Owned, MainTemplate, OtherTemplate)
    End If
    Return MyBase.SelectTemplate(item, container)
  End Function

End Class
