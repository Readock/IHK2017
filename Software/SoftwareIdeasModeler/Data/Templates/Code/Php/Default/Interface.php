<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:Set:private=private==%><%==SIM:Set:protected=protected==%><%==SIM:Set:package=public==%><%==SIM:Set:public=public==%>
  
<?php
<%==SIM:Line==%>

<%==SIM:ForEach:Element.DocumentationLines==%>
  //<%==SIM:DocumentationLine==%>
  <%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:If:Element.IsAbstract==%>abstract <%==SIM:EndIf==%>interface <%==SIM:Element.Name==%><%==SIM:If:Element.HasInterfaces==%> extends <%==SIM:ForEach:Element.Interfaces==%><%==SIM:Interface.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%><%==SIM:EndIf==%>
<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>

  <%==SIM:ForEach:Element.Operations==%>
      <%==SIM:ForEach:Operation.DocumentationLines==%>
        //<%==SIM:DocumentationLine==%>
        <%==SIM:Line==%>
      <%==SIM:EndFor==%>
      
      <%==SIM:Operation.Visibility==%> function <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%>/*<%==SIM:Parameter.Type==%>*/ $<%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>);    
      <%==SIM:Line==%>
  <%==SIM:EndFor==%>
  
<%==SIM:EndBlock==%><%==SIM:Line==%>
}<%==SIM:Line==%>
?>
<%==SIM:Line==%>