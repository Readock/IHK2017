<%==SIM:ExplicitLinesOn==%>
<%==SIM:Set:private=Private==%>
<%==SIM:Set:protected=Protected==%>
<%==SIM:Set:package=Friend==%>
<%==SIM:Set:public=Public==%>
Imports NHibernate<%==SIM:Line==%>
Imports NHibernate.Criterion<%==SIM:Line(2)==%>

Namespace <%==SIM:Element.Namespace==%><%==SIM:Line(2)==%>
<%==SIM:ForEach:Element.DocumentationLines==%>'<%==SIM:DocumentationLine==%><%==SIM:Line==%>
<%==SIM:EndFor==%>
    Public Class <%==SIM:Element.Name==%><%==SIM:Line(2)==%>

<%==SIM:ForEach:Element.AllAttributes==%>
        Public Overridable Property <%==SIM:Attribute.Name==%> As <%==SIM:Attribute.TypeName==%><%==SIM:IfNot:Attribute.ReplacedType.IsNullable==%><%==SIM:If:Attribute.IsNullable==%>?<%==SIM:EndIf==%><%==SIM:EndIf==%>
<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.InverseReferences==%>
        Public Overridable Property <%==SIM:Reference.Name==%> As IList(Of <%==SIM:Reference.ForeignKeyEntity.Name==%>) = New List(Of <%==SIM:Reference.ForeignKeyEntity.Name==%>)             
<%==SIM:Line==%>
<%==SIM:EndFor==%>
<%==SIM:Line==%>

<%==SIM:If:GreaterThan(Element.PrimaryKeys.Count,1)==%>
        Public Overrides Function Equals(ByVal obj As Object) As Boolean<%==SIM:Line==%>
            Dim other As <%==SIM:Element.Name==%> = CType(obj, <%==SIM:Element.Name==%>)<%==SIM:Line==%>
            If <%==SIM:ForEach:Element.PrimaryKeys==%> Me.<%==SIM:Key.Name==%> = other.<%==SIM:Key.Name==%><%==SIM:IfNot:IsLastItem==%> AndAlso <%==SIM:EndIf==%><%==SIM:EndFor==%> Then<%==SIM:Line==%>
                Return True<%==SIM:Line==%>
            Else<%==SIM:Line==%>
                Return False<%==SIM:Line==%>
            End If<%==SIM:Line==%>
        End Function<%==SIM:Line==%>
        <%==SIM:Line==%>
        Public Overrides Function GetHashCode() As Integer<%==SIM:Line==%>
            Dim hash As Long<%==SIM:Line==%>

            hash = <%==SIM:ForEach:Element.PrimaryKeys==%> CLng(Me.<%==SIM:Key.Name==%>.GetHashCode())<%==SIM:IfNot:IsLastItem==%> + <%==SIM:EndIf==%><%==SIM:EndFor==%>
            <%==SIM:Line==%><%==SIM:Line==%>
            Return hash Mod Integer.MaxValue<%==SIM:Line==%>
        End Function<%==SIM:Line==%>
<%==SIM:EndIf==%>
<%==SIM:Line==%>

    End Class<%==SIM:Line==%>
End Namespace<%==SIM:Line==%>

