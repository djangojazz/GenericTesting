using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockMarket
{
  public partial class StockViewerForm : Form
  {
    private readonly IAuthenticationService authenticationService;
    private readonly IStockPortfolioService portfolioService;
    private readonly IStockPriceService priceService;

    public StockViewerForm() : this(null, null, null)
    {
    }

    public StockViewerForm(IAuthenticationService aAuthenticationService, IStockPortfolioService aStockPortfolioService, IStockPriceService aStockPriceService)
    {
      authenticationService = aAuthenticationService;
      portfolioService = aStockPortfolioService;
      priceService = aStockPriceService;
    }

    private void bFetchStocks_Click(object sender, EventArgs e)
    {
      try
      {
        fetchButton.Enabled = false;

        
      }
      catch (Exception)
      {

        throw;
      }
      finally
      {

      }
    }
  }
}
