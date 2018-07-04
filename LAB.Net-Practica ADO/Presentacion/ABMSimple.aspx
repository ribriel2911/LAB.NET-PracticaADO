<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMSimple.aspx.cs" Inherits="Presentacion.ABMSimple" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AMB Simple Entity Framework</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"
        integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-lg-12">
            <asp:GridView ID="Grid1" runat="server" OnSelectedIndexChanged="Grid1_SelectedIndexChanged" class="table table-striped">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" ButtonType="button" ControlStyle-CssClass="btn btn-success"/>
                </Columns>
            </asp:GridView>
            <div class="form-group col-lg-6">
                <label for="txtRegionId">RegionID</label>
                <asp:TextBox ID="txtRegionId" runat="server" class="form-control" /><br />
            </div>
            <div class="form-group col-lg-6">
                <label for="txtDescription">Description</label>
                <asp:TextBox ID="txtDescription" runat="server" class="form-control" />
                <br />
            </div>
            <div class="form-group col-lg-6">
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" class="btn btn-default" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" class="btn btn-info" />
                <asp:Button ID="btnEliminar" runat="server" Text="Borrar" OnClick="btnEliminar_Click" class="btn btn-danger" />
            </div>
        </div>
    </form>
</body>
</html>
