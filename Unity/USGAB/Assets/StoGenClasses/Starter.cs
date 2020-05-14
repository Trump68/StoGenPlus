using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.StoGenClasses
{
    public class Starter
    {
        public void Go()
        {
            string file = @"";
            List<string> clipsinstr = new List<string>(File.ReadAllLines(file));
            StoryBase story = new StoryBase();
            story.GamePath = Path.GetDirectoryName(file);
            story.LoadFrom(clipsinstr);
            //StoGenWPF.MainWindow.ReadIni(file);

            BaseScene scene = null;
            scene = new StoryScene();
                ((StoryScene)scene).SetScenario(story, story.SceneInfos[0].Queue);


            //StoGenWPF.MainWindow window = new StoGenWPF.MainWindow();
            //Projector.ProjectorWindow = window;
            //window.GlobalMenuCreator = GameWorldFactory.GameWorld;
            //window.Scene = scene;
            //window.Show();
            //window.IsVisibleChanged += Window_IsVisibleChanged;
        }       
    }
}
