using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilerNS;
using DesignerNS;
using GameNS;

namespace WinFormNS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //<<VIEW>>
            BaseForm baseFrm = new BaseForm();
            IGameView gameView = new GameFormView();
            IFilerView filerView = new FilerFormView();
            /*MANUAL DESIGNER*/
            //IManualDesignerView manualDesignerView = new ManualDesignerFormView();
            /*DYNAMIC BUTTONS*/
            //IDesignerButtonView designerButtonView = new DesignerButtonFormView();
            /*DYNAMIC DRAWING VIEW*/
            IDesignerView designerView = new DesignerFormView();


            //<<MODELS>>
            IFiler filer = new Filer();
            IDesigner designer = new Designer();
            IGame game = new Game();
            IFileable designerFileable = (IFileable)designer;
            IFileable gameFileable = (IFileable)game;
            baseFrm.StartPosition = FormStartPosition.CenterScreen;

            //<<CONTROLLERS>>
            IGameController gameController = new GameController(gameView, filerView, filer, game, gameFileable);
            /*MANUAL DESIGNER*/
            //IDesignerController designerController = new DesignerController(manualDesignerView, filerView, filer, designer, designerFileable);
            /*DYNAMIC BUTTONS*/
            //IDesignerController designerController = new DesignerController(designerButtonView, filerView, filer, designer, designerFileable);
            /*DYNAMIC DRAWING VIEW*/
            IDesignerController designerController = new DesignerController(designerView, filerView, filer, designer, designerFileable);


            //<<SET CONTROLLERS>>
            baseFrm.SetControllers(gameController, designerController);
            /*MANUAL DESIGNER*/
            //manualDesignerView.SetController(designerController);

            Application.Run(baseFrm);


        }
    }
}
