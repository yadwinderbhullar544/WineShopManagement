﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WineView.aspx.cs" Inherits="WineShopManagement.WineView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content" class="col-lg-10 col-sm-10">
        <!-- content starts -->
        <div>
            <ul class="breadcrumb">
                <li>
                    <a runat="server" href="~/">Home</a>
                </li>
                <li>
                    <a runat="server" href="~/Wine">Wine</a>
                </li>
            </ul>
        </div>
        <div class="row">
            <div class="box col-md-12">
                <div class="box-inner">
                    <div class="box-header well" data-original-title="">
                        <h2><i class="glyphicon glyphicon-edit"></i>Form Elements</h2>

                        <div class="box-icon">
                            <a href="#" class="btn btn-minimize btn-round btn-default"><i
                                class="glyphicon glyphicon-chevron-up"></i></a>
                        </div>
                    </div>
                    <div class="box-content" style="padding:45px;">
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <div class="form-group">
                            <label for="exampleInputName">Name<span style="color: red;">*</span></label>
                            <asp:TextBox ID="txtName" class="form-control" runat="server" placeholder="Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" ValidationGroup="Save" runat="server" ControlToValidate="txtName" ErrorMessage="Please enter Name" ForeColor="#993333"></asp:RequiredFieldValidator>
                        </div>

                        <asp:Button ID="Submit" ValidationGroup="Save" runat="server" class="btn btn-success pull-right" Text="Submit" OnClick="Submit_Click" />
                        <asp:Button ID="Reset" runat="server" class="btn btn-danger pull-right" Text="Reset" OnClick="Reset_Click" />
                    </div>
                </div>
                <!--/span-->

            </div>
        </div>
        <div class="row">
            <div class="box col-md-12" style="margin-top: 25px">
                <div class="box-inner">
                    <div class="box-header well" data-original-title="">
                        <h2><i class="glyphicon glyphicon-user"></i>List </h2>

                        <div class="box-icon">
                            <a href="#" class="btn btn-minimize btn-round btn-default"><i
                                class="glyphicon glyphicon-chevron-up"></i></a>
                        </div>
                    </div>
                    <div class="">
                        <div class="box-body">
                            <div id="datatable-responsive_wrapper" class="dataTables_wrapper form-inline dt-bootstrap no-footer">
                                <asp:GridView ID="grd" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" CaptionAlign="Top" AllowPaging="True"
                                    EnableSortingAndPagingCallbacks="True" PageSize="5" HorizontalAlign="Left" AllowSorting="True">
                                    <AlternatingRowStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ID" />
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                    </Columns>
                                    <EditRowStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <EmptyDataRowStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="Black" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <SortedAscendingCellStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <SortedAscendingHeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <SortedDescendingCellStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <SortedDescendingHeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--/span-->

        </div>
    </div>
</asp:Content>
