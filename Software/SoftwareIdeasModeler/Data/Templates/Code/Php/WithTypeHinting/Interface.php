<?php
<%==SIM:Set:private=private==%><%==SIM:Set:protected=protected==%><%==SIM:Set:package=public==%><%==SIM:Set:public=public==%>
<%==SIM:ForEach:Element.DocumentationLines==%>//<%==SIM:DocumentationLine==%>
<%==SIM:EndFor==%><%==SIM:If:Element.IsAbstract==%> abstract<%==SIM:EndIf==%> interface <%==SIM:Element.Name==%><%==SIM:If:Element.HasSuperClass==%> extends <%==SIM:Element.SuperClass.Name==%><%==SIM:EndIf==%>
{
<%==SIM:ForEach:Element.Operations==%>
    <%==SIM:ForEach:Operation.DocumentationLines==%>//<%==SIM:DocumentationLine==%>
    <%==SIM:EndFor==%><%==SIM:Operation.Visibility==%> function <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Type==%> $<%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>);    

<%==SIM:EndFor==%>
}
?>