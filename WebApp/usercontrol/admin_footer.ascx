<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="admin_footer.ascx.cs" Inherits="MyNews.admin_footer" %>

<style type="text/css">
    /*.hotline2 {
        z-index: 99999999999;
        position: fixed;
        bottom: 0px;
        left: 10px;
        width: 150px;
        background: #FF3838;
        height: 40px;
        border-radius: 25px;
        position: fixed;
        text-align: center;
        z-index: 20;
        padding: 10px;
    }*/

    .callimages {
        display: block;
        width: 150px;
        cursor: pointer;
        height: 40px;
        text-align: center;
        color: #fff;
        font-weight: bold;
        font-size: 14px;
        line-height: 24px;
        /*background: url('phone.png/) no-repeat left 8px center;*/
        margin: auto;
        border-radius: 5px 5px 0 0;
        padding: 10px 0 5px 20px;
        z-index: 1000 !important;
        opacity: .8;
    }

    .call .callimages span a {
        color: #fff;
        font-weight: bold;
    }

    .go-top {
        bottom: 0px;
        cursor: pointer;
        display: none;
        position: fixed;
        right: 0px;
        z-index: 1000;
        width: 40px;
        height: 40px;
        text-align: center;
        line-height: 40px;
        color: #fff;
        border-radius: 5px;
        background: rgba(0,0,0,.4);
    }
</style>
<script>
    $(document).ready(function () {
        // Show or hide the sticky footer button
        $(window).scroll(function () {
            if ($(this).scrollTop() > 200) {
                $('.go-top').fadeIn(200);
            } else {
                $('.go-top').fadeOut(200);
            }
        });

        // Animate the scroll to top
        $('.go-top').click(function (event) {
            event.preventDefault();

            $('html, body').animate({ scrollTop: 0 }, 300);
        })
    });

</script>
<footer id="footer" class="midnight-blue" style="padding-bottom:0px">

    <div class="features" style="background: #009900; padding-left: 15px; padding-right: 15px">
        <div class="container">
            <div class="row" style="padding-top: 20px">
                <asp:Repeater ID="rpt" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-12">
                            <p style="font-size: 16px; font-weight: bold"><%#Eval("name") %></p>

                            <%#Eval("address") %>
                            <br />
                            <%#Eval("phone") %>
                           
                             
                           
                        </div>
                      
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>
      
        <a href="#" class="go-top" title="Về đầu trang">
          
            <i class="fa fa-arrow-up" aria-hidden="true"></i>

        </a>
    </div>
    <%-- </div>--%>
</footer>
