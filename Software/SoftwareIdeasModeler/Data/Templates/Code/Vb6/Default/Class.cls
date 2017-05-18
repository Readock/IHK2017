VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "<%==SIM:Element.Name==%>"
Attribute VB_Creatable = True
Attribute VB_Exposed = False
Option Explicit
<%==SIM:Set:private=Private==%>
<%==SIM:Set:protected=Private==%>
<%==SIM:Set:package=Public==%>
<%==SIM:Set:public=Public==%>

<%==SIM:ForEach:Element.DocumentationLines==%>' <%==SIM:DocumentationLine==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.AllAttributes==%>
Private m<%==SIM:Attribute.Name==%> As <%==SIM:Attribute.Type==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.AllAttributes==%>
<%==SIM:ForEach:Attribute.DocumentationLines==%>'<%==SIM:DocumentationLine==%>
<%==SIM:EndFor==%><%==SIM:Attribute.Visibility==%> Property Let <%==SIM:Attribute.Name==%> (value As <%==SIM:Attribute.Type==%>)
    m<%==SIM:Attribute.Name==%> = value
End Property

<%==SIM:Attribute.Visibility==%> Property Get <%==SIM:Attribute.Name==%> () As <%==SIM:Attribute.Type==%>    
    <%==SIM:Attribute.Name==%> = m<%==SIM:Attribute.Name==%>
End Property
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.Operations==%>
<%==SIM:ForEach:Operation.DocumentationLines==%>'<%==SIM:DocumentationLine==%>
<%==SIM:EndFor==%><%==SIM:Operation.Visibility==%> <%==SIM:If:Operation.HasReturnType==%>Function<%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>Sub<%==SIM:EndIf==%> <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%> As <%==SIM:Parameter.Type==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>) <%==SIM:If:Operation.HasReturnType==%>As <%==SIM:Operation.ReturnType==%><%==SIM:EndIf==%>

End <%==SIM:If:Operation.HasReturnType==%>Function<%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>Sub<%==SIM:EndIf==%>
<%==SIM:EndFor==%>