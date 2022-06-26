using MoreDifferentDots.Objects;
using Zenject;
using SiraUtil.Objects.Beatmap;
using SiraUtil.Extras;

namespace MoreDifferentDots.Installers
{
    public class ADGameInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.RegisterRedecorator(new BasicNoteRegistration(DecorateNote));
        }

        private GameNoteController DecorateNote(GameNoteController original)
        {
            original.gameObject.AddComponent<NoteDotController>();
            return original;
        }
    }
} 