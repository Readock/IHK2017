<%==SIM:ForEach:Element.DocumentationLines==%>//<%==SIM:DocumentationLine==%>
<%==SIM:EndFor==%>function <%==SIM:Element.Name==%>
{
<%==SIM:ForEach:Element.AllAttributes==%>
    <%==SIM:ForEach:Attribute.DocumentationLines==%>//<%==SIM:DocumentationLine==%>
    <%==SIM:EndFor==%>this.<%==SIM:Attribute.Name==%><%==SIM:If:Attribute.HasDefaultValue==%>= <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>;
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.Operations==%>
	<%==SIM:ForEach:Operation.DocumentationLines==%>//<%==SIM:DocumentationLine==%>
    <%==SIM:EndFor==%>this.<%==SIM:Operation.Name==%> = function(<%==SIM:ForEach:Operation.Parameters==%> /* <%==SIM:Parameter.Type==%> */ <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>) 
    {
        /* Method body */
    }

<%==SIM:EndFor==%>
}

<%==SIM:If:Element.HasSuperClass==%><%==SIM:Element.Name==%>.prototype = new <%==SIM:Element.SuperClass.Name==%>()<%==SIM:EndIf==%>
