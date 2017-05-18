<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:Set:private=private==%>
<%==SIM:Set:protected=protected==%>
<%==SIM:Set:package===%>
<%==SIM:Set:public=public==%>

unit <%==SIM:Element.Name==%>Unit;
<%==SIM:Line(2)==%>

interface
<%==SIM:Line(2)==%>

<%==SIM:ForEach:Element.DocumentationLines==%>
	//<%==SIM:DocumentationLine==%>
	<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:If:HasImports==%>
uses
<%==SIM:StartBlock==%><%==SIM:Line==%>

    <%==SIM:ForEach:Imports==%>
		<%==SIM:Import.Name==%>
		<%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%>		
	<%==SIM:EndFor==%>;
	<%==SIM:EndBlock==%><%==SIM:Line==%>
<%==SIM:Line==%>

<%==SIM:EndIf==%>

type
<%==SIM:StartBlock==%><%==SIM:Line==%>
    <%==SIM:Element.Name==%> = class<%==SIM:If:Element.IsAbstract==%> abstract<%==SIM:EndIf==%><%==SIM:If:Element.IsLeaf==%> sealed<%==SIM:EndIf==%> <%==SIM:If:Element.HasSuperClassOrInterface==%>(<%==SIM:Element.SuperClass.Name==%><%==SIM:If:Element.HasInterfaces==%><%==SIM:If:Element.HasSuperClass==%>, <%==SIM:EndIf==%><%==SIM:ForEach:Element.Interfaces==%><%==SIM:Interface.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%><%==SIM:EndIf==%>)<%==SIM:EndIf==%>	
	<%==SIM:StartBlock==%><%==SIM:Line(2)==%>


<%==SIM:Set:first=1==%>

<%==SIM:ForEach:Element.AllAttributes==%>	
    <%==SIM:IfNot:Attribute.IsStatic==%><%==SIM:If:Equals(Attribute.Visibility,private)==%>
		<%==SIM:If:Equals(first,1)==%>
			<%==SIM:Set:first=0==%>
			private
			<%==SIM:StartBlock==%><%==SIM:Line==%>
		<%==SIM:EndIf==%>

		<%==SIM:ForEach:Attribute.DocumentationLines==%>
			// <%==SIM:DocumentationLine==%>
			<%==SIM:Line==%>
		<%==SIM:EndFor==%>

		<%==SIM:Attribute.Name==%> : <%==SIM:Attribute.Type==%>; 
		<%==SIM:Line==%>

	<%==SIM:EndIf==%><%==SIM:EndIf==%>
<%==SIM:EndFor==%>	

<%==SIM:ForEach:Element.Operations==%>
	<%==SIM:If:Equals(Operation.Visibility,private)==%>	
		<%==SIM:If:Equals(first,1)==%>
			<%==SIM:Set:first=0==%>
			private
			<%==SIM:StartBlock==%><%==SIM:Line==%>
		<%==SIM:EndIf==%>

		<%==SIM:ForEach:Operation.DocumentationLines==%>
			//<%==SIM:DocumentationLine==%>
			<%==SIM:Line==%>
		<%==SIM:EndFor==%>
	
		<%==SIM:IfNot:Operation.HasReturnType==%>
			<%==SIM:If:Operation.IsStatic==%>class <%==SIM:EndIf==%>procedure  <%==SIM:Operation.Name==%>(<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%> : <%==SIM:Parameter.Type==%><%==SIM:IfNot:IsLastItem==%>; <%==SIM:EndIf==%><%==SIM:EndFor==%>);
			<%==SIM:If:Or(Operation.IsVirtual,Operation.IsAbstract)==%> virtual;<%==SIM:EndIf==%>
			<%==SIM:If:Operation.IsAbstract==%> abstract;<%==SIM:EndIf==%>
			<%==SIM:If:Operation.IsOverloaded==%> overload;<%==SIM:EndIf==%>
		<%==SIM:EndIf==%>

		<%==SIM:If:Operation.HasReturnType==%>
			<%==SIM:If:Operation.IsStatic==%>class <%==SIM:EndIf==%>function <%==SIM:Operation.Name==%>(<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%> : <%==SIM:Parameter.Type==%><%==SIM:IfNot:IsLastItem==%>; <%==SIM:EndIf==%><%==SIM:EndFor==%>) : <%==SIM:Operation.ReturnType==%>;
			<%==SIM:If:Or(Operation.IsVirtual,Operation.IsAbstract)==%> virtual;<%==SIM:EndIf==%>
			<%==SIM:If:Operation.IsAbstract==%> abstract;<%==SIM:EndIf==%>
			<%==SIM:If:Operation.IsOverloaded==%> overload;<%==SIM:EndIf==%>
		<%==SIM:EndIf==%>	

		<%==SIM:Line==%>

	<%==SIM:EndIf==%>
<%==SIM:EndFor==%>

<%==SIM:If:Equals(first,0)==%>
	<%==SIM:Set:first=1==%>	
	<%==SIM:EndBlock==%><%==SIM:Line==%>	
<%==SIM:EndIf==%>



<%==SIM:ForEach:Element.AllAttributes==%>

    <%==SIM:IfNot:Attribute.IsStatic==%><%==SIM:If:Equals(Attribute.Visibility,protected)==%>
		<%==SIM:If:Equals(first,1)==%>
			<%==SIM:Set:first=0==%>
			protected
			<%==SIM:StartBlock==%><%==SIM:Line==%>
		<%==SIM:EndIf==%>
    
		<%==SIM:ForEach:Attribute.DocumentationLines==%>
			// <%==SIM:DocumentationLine==%> 
			<%==SIM:Line==%>
		<%==SIM:EndFor==%>
		
		<%==SIM:Attribute.Name==%> : <%==SIM:Attribute.Type==%>; 
		<%==SIM:Line==%>
	<%==SIM:EndIf==%><%==SIM:EndIf==%>
<%==SIM:EndFor==%>
		
<%==SIM:ForEach:Element.Operations==%>
	<%==SIM:If:Equals(Operation.Visibility,protected)==%>
		<%==SIM:If:Equals(first,1)==%>
			<%==SIM:Set:first=0==%>
			protected
			<%==SIM:StartBlock==%><%==SIM:Line==%>
		<%==SIM:EndIf==%>

		<%==SIM:ForEach:Operation.DocumentationLines==%>
			//<%==SIM:DocumentationLine==%>
			<%==SIM:Line==%>
		<%==SIM:EndFor==%>
		
		<%==SIM:IfNot:Operation.HasReturnType==%>
			<%==SIM:If:Operation.IsStatic==%>class <%==SIM:EndIf==%>procedure  <%==SIM:Operation.Name==%>(<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%> : <%==SIM:Parameter.Type==%><%==SIM:IfNot:IsLastItem==%>; <%==SIM:EndIf==%><%==SIM:EndFor==%>);
			<%==SIM:If:Or(Operation.IsVirtual,Operation.IsAbstract)==%> virtual;<%==SIM:EndIf==%>
			<%==SIM:If:Operation.IsAbstract==%> abstract;<%==SIM:EndIf==%>
			<%==SIM:If:Operation.IsOverloaded==%> overload;<%==SIM:EndIf==%>
		<%==SIM:EndIf==%>
		
		<%==SIM:If:Operation.HasReturnType==%>
			<%==SIM:If:Operation.IsStatic==%>class <%==SIM:EndIf==%>function <%==SIM:Operation.Name==%>(<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%> : <%==SIM:Parameter.Type==%><%==SIM:IfNot:IsLastItem==%>; <%==SIM:EndIf==%><%==SIM:EndFor==%>) : <%==SIM:Operation.ReturnType==%>;
			<%==SIM:If:Or(Operation.IsVirtual,Operation.IsAbstract)==%> virtual;<%==SIM:EndIf==%>
			<%==SIM:If:Operation.IsAbstract==%> abstract;<%==SIM:EndIf==%>
			<%==SIM:If:Operation.IsOverloaded==%> overload;<%==SIM:EndIf==%>
		<%==SIM:EndIf==%>

		<%==SIM:Line==%>
	<%==SIM:EndIf==%>
<%==SIM:EndFor==%>

<%==SIM:If:Equals(first,0)==%>
	<%==SIM:Set:first=1==%>	
	<%==SIM:EndBlock==%><%==SIM:Line==%>	
<%==SIM:EndIf==%>



<%==SIM:ForEach:Element.AllAttributes==%>

    <%==SIM:IfNot:Attribute.IsStatic==%><%==SIM:If:Equals(Attribute.Visibility,public)==%>
		<%==SIM:If:Equals(first,1)==%>
			<%==SIM:Set:first=0==%>
			public
			<%==SIM:StartBlock==%><%==SIM:Line==%>
		<%==SIM:EndIf==%>

		<%==SIM:ForEach:Attribute.DocumentationLines==%>
			// <%==SIM:DocumentationLine==%> 
			<%==SIM:Line==%>
		<%==SIM:EndFor==%>
		
		<%==SIM:Attribute.Name==%> : <%==SIM:Attribute.Type==%>; 
		<%==SIM:Line==%>
	<%==SIM:EndIf==%><%==SIM:EndIf==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.Operations==%>
	<%==SIM:If:Equals(Operation.Visibility,public)==%>
		<%==SIM:If:Equals(first,1)==%>
			<%==SIM:Set:first=0==%>
			public
			<%==SIM:StartBlock==%><%==SIM:Line==%>
		<%==SIM:EndIf==%>

		<%==SIM:ForEach:Operation.DocumentationLines==%>
			//<%==SIM:DocumentationLine==%>
			<%==SIM:Line==%>
		<%==SIM:EndFor==%>
	
		<%==SIM:IfNot:Operation.HasReturnType==%>
			<%==SIM:If:Operation.IsStatic==%>class <%==SIM:EndIf==%>procedure  <%==SIM:Operation.Name==%>(<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%> : <%==SIM:Parameter.Type==%><%==SIM:IfNot:IsLastItem==%>; <%==SIM:EndIf==%><%==SIM:EndFor==%>);
			<%==SIM:If:Or(Operation.IsVirtual,Operation.IsAbstract)==%> virtual;<%==SIM:EndIf==%>			
			<%==SIM:If:Operation.IsAbstract==%> abstract;<%==SIM:EndIf==%>
			<%==SIM:If:Operation.IsOverloaded==%> overload;<%==SIM:EndIf==%>
		<%==SIM:EndIf==%>

		<%==SIM:If:Operation.HasReturnType==%>
			<%==SIM:If:Operation.IsStatic==%>class <%==SIM:EndIf==%>function <%==SIM:Operation.Name==%>(<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%> : <%==SIM:Parameter.Type==%><%==SIM:IfNot:IsLastItem==%>; <%==SIM:EndIf==%><%==SIM:EndFor==%>) : <%==SIM:Operation.ReturnType==%>;
			<%==SIM:If:Or(Operation.IsVirtual,Operation.IsAbstract)==%> virtual;<%==SIM:EndIf==%>
			<%==SIM:If:Operation.IsAbstract==%> abstract;<%==SIM:EndIf==%>
			<%==SIM:If:Operation.IsOverloaded==%> overload;<%==SIM:EndIf==%>
		<%==SIM:EndIf==%>

		<%==SIM:Line==%>
	<%==SIM:EndIf==%>
<%==SIM:EndFor==%>

<%==SIM:If:Equals(first,0)==%>
	<%==SIM:Set:first=1==%>	
	<%==SIM:EndBlock==%><%==SIM:Line==%>	
<%==SIM:EndIf==%>


<%==SIM:EndBlock==%><%==SIM:Line==%>
end;
<%==SIM:Line(2)==%>


implementation
<%==SIM:StartBlock==%><%==SIM:Line(2)==%>

<%==SIM:ForEach:Element.Operations==%>
	<%==SIM:IfNot:Operation.IsAbstract==%>
    <%==SIM:IfNot:Operation.HasReturnType==%><%==SIM:If:Operation.IsStatic==%>class <%==SIM:EndIf==%>procedure  <%==SIM:Element.Name==%>.<%==SIM:Operation.Name==%>(<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%> : <%==SIM:Parameter.Type==%><%==SIM:IfNot:IsLastItem==%>; <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:EndIf==%><%==SIM:If:Operation.HasReturnType==%><%==SIM:If:Operation.IsStatic==%>class <%==SIM:EndIf==%>function <%==SIM:Element.Name==%>.<%==SIM:Operation.Name==%>(<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%> : <%==SIM:Parameter.Type==%><%==SIM:IfNot:IsLastItem==%>; <%==SIM:EndIf==%><%==SIM:EndFor==%>) : <%==SIM:Operation.ReturnType==%><%==SIM:EndIf==%>;	
	<%==SIM:Line==%>
    begin
	<%==SIM:StartBlock==%><%==SIM:Line==%>

        <%==SIM:Operation.SourceCodeBody==%>
		
		<%==SIM:EndBlock==%><%==SIM:Line==%>
    end;
	<%==SIM:Line(2)==%>
	<%==SIM:EndIf==%>
<%==SIM:EndFor==%>

<%==SIM:EndBlock==%><%==SIM:EndBlock==%><%==SIM:Line==%>
end.
<%==SIM:Line==%>