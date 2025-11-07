<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GrievanceInfo.ascx.cs" Inherits="Pharmacy2024.UserControls.GrievanceInfo" %>

<style>
	.card-header {
		padding: 0.25rem 0.75rem;
		font-size:16px;
		font-weight:500;
	}
	.card-body {
		font-size:13px;
	}
</style>
<div class="card mb-3">
    <div class="card-header text-center" style="background:#ccc">
        Ticket ID&nbsp;:&nbsp;<asp:Label ID="GrievanceID" runat="server"></asp:Label>
    </div>
	<div class="card-body" style="background:#fbf6f0a8">
		<div class="row p-1">
		    <div class="col-md-6">
			    <b>Login ID :</b> <asp:Label ID="ApplicationID" runat="server"></asp:Label>
		    </div>
            <div class="col-md-6">
			    <b>Category :</b> <asp:Label ID="GrievanceCategory" runat="server"></asp:Label>
		    </div>
	    </div>
        <div class="row p-1">
		    <div class="col-md-6">
			    <b>Sent By :</b> <asp:Label ID="SentBy" runat="server"></asp:Label>
		    </div>
            <div class="col-md-6">
			    <b>Sent Date Time :</b> <asp:Label ID="SentDateTime" runat="server"></asp:Label>
		    </div>
	    </div>
        <div class="row p-1">
		    <div class="col-md-12" style="background:#feeced">
			    <b>Query :</b> <br /><asp:Label ID="Grievance" runat="server"></asp:Label>
		    </div>
	    </div>
        <div id="divRepliedGrievance1" runat="server" visible="false" class="row p-1">
		    <div class="col-md-6">
			    <b>Replied By :</b> <asp:Label ID="RepliedBy" runat="server"></asp:Label>
		    </div>
            <div class="col-md-6">
			    <b>Replied Date Time :</b> <asp:Label ID="RepliedDateTime" runat="server"></asp:Label>
		    </div>
	    </div>
        <div id="divRepliedGrievance2" runat="server" visible="false" class="row p-1" style="background:#e6fef0">
		    <div class="col-md-6">
			    <b>Replied Message :</b> <br /><asp:Label ID="RepliedGrievance" runat="server"></asp:Label>
		    </div>
	    </div>
        <div class="row p-1">
		    <div class="col-md-6">
			    <b>Current Status :</b> <asp:Label ID="GrievanceStatus" runat="server"></asp:Label>
		    </div>
            <div class="col-md-6">
			    <b>Updated Date Time :</b> <asp:Label ID="GrievanceStatusUpdatedDateTime" runat="server"></asp:Label>
		    </div>
	    </div>
	</div>
</div>
