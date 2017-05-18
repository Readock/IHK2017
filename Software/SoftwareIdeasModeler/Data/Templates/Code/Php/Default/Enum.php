<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:Set:private=private==%><%==SIM:Set:protected=protected==%><%==SIM:Set:package=public==%><%==SIM:Set:public=public==%>

<?php
<%==SIM:Line==%>

<%==SIM:ForEach:Element.DocumentationLines==%>
  //<%==SIM:DocumentationLine==%>
  <%==SIM:Line==%>
<%==SIM:EndFor==%>

final class <%==SIM:Element.Name==%> {
<%==SIM:StartBlock==%><%==SIM:Line==%>

<%==SIM:ForEach:Element.Attributes==%>
  
  <%==SIM:ForEach:Element.DocumentationLines==%>
    //<%==SIM:DocumentationLine==%>
    <%==SIM:Line==%>
  <%==SIM:EndFor==%>    
  
  const <%==SIM:Attribute.Name==%><%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>;
  <%==SIM:Line==%>
  
<%==SIM:EndFor==%>

    <%==SIM:Line==%>
    private function __construct(){}
    
<%==SIM:EndBlock==%><%==SIM:Line==%>
}<%==SIM:Line==%>
?>

<%==SIM:Line==%>