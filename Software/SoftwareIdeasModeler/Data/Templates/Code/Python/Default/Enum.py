<%==SIM:ForEach:Element.DocumentationLines==%>#<%==SIM:DocumentationLine==%>
<%==SIM:EndFor==%>class <%==SIM:Element.Name==%>:
<%==SIM:ForEach:Element.Attributes==%>
    <%==SIM:ForEach:Attribute.DocumentationLines==%>#<%==SIM:DocumentationLine==%>
    <%==SIM:EndFor==%><%==SIM:Attribute.Name==%> <%==SIM:If:Attribute.HasDefaultValue==%>= <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%><%==SIM:EndFor==%>
