using GameEditor.Views.Base;
using System;
using System.Collections.Generic;

namespace GameEditor.Controllers.Base
{
    public class Controller : IController
    {
        private IView _view;
        private const string CreateText = "Create";
        private const string ReadText = "Read";
        private const string UpdateText = "Update";
        private const string DeleteText = "Delete";

        protected Controller()
        {

        }

        protected Controller(IView view)
        {
            _view = view;
        }

        protected void SetView(IView view)
        {
            _view = view;
        }

        public virtual void UpdateView()
        {
            SetButtonText();
        }

        private void SetButtonText()
        {
            var buttonMap = new Dictionary<int, Action>
            {
                { 0, ()=> { _view.Button1Visible = _view.Button2Visible=_view.Button3Visible=_view.Button4Visible=false; } },
                { 1, ()=>
                {
                    _view.Button4Text = CreateText;
                    _view.Button1Visible = _view.Button2Visible = _view.Button3Visible = false;
                    _view.Button4Visible = true;
                } },
                { 2, ()=>
                {
                    _view.Button4Text = ReadText;
                    _view.Button1Visible = _view.Button2Visible = _view.Button3Visible = false;
                    _view.Button4Visible = true;
                } },
                { 3, ()=>
                {
                    _view.Button3Text = CreateText;
                    _view.Button4Text = ReadText;
                    _view.Button1Visible = _view.Button2Visible = false;
                    _view.Button3Visible = _view.Button4Visible = true;
                } },
                { 4, ()=>
                {
                    _view.Button4Text = UpdateText;
                    _view.Button1Visible = _view.Button2Visible = _view.Button3Visible = false;
                    _view.Button4Visible = true;
                } },
                { 5, ()=>
                {
                    _view.Button3Text = CreateText;
                    _view.Button4Text = UpdateText;
                    _view.Button1Visible = _view.Button2Visible = false;
                    _view.Button3Visible = _view.Button4Visible = true;
                } },
                { 6, ()=>
                {
                    _view.Button3Text = ReadText;
                    _view.Button4Text = UpdateText;
                    _view.Button1Visible = _view.Button2Visible = false;
                    _view.Button3Visible = _view.Button4Visible = true;
                } },
                { 7, ()=>
                {
                    _view.Button2Text = CreateText;
                    _view.Button3Text = ReadText;
                    _view.Button4Text = UpdateText;
                    _view.Button1Visible = false;
                    _view.Button2Visible = _view.Button3Visible = _view.Button4Visible = true;
                } },
                { 8, ()=>
                {
                    _view.Button4Text = DeleteText;
                    _view.Button1Visible = _view.Button2Visible = _view.Button3Visible = false;
                    _view.Button4Visible = true;
                } },
                { 9, ()=>
                {
                    _view.Button3Text = CreateText;
                    _view.Button4Text = DeleteText;
                    _view.Button1Visible = _view.Button2Visible = false;
                    _view.Button3Visible = _view.Button4Visible = true;
                } },
                { 10, ()=>
                {
                    _view.Button3Text = ReadText;
                    _view.Button4Text = DeleteText;
                    _view.Button1Visible = _view.Button2Visible = false;
                    _view.Button3Visible = _view.Button4Visible = true;
                } },
                { 11, ()=>
                {
                    _view.Button2Text = CreateText;
                    _view.Button3Text = ReadText;
                    _view.Button4Text = DeleteText;
                    _view.Button1Visible = false;
                    _view.Button2Visible = _view.Button3Visible = _view.Button4Visible = true;
                } },
                { 12, ()=>
                {
                    _view.Button3Text = UpdateText;
                    _view.Button4Text = DeleteText;
                    _view.Button1Visible = _view.Button2Visible = false;
                    _view.Button3Visible = _view.Button4Visible = true;
                } },
                { 13, ()=>
                {
                    _view.Button2Text = CreateText;
                    _view.Button3Text = UpdateText;
                    _view.Button4Text = DeleteText;
                    _view.Button1Visible = false;
                    _view.Button2Visible = _view.Button3Visible = _view.Button4Visible = true;
                } },
                { 14, ()=>
                {
                    _view.Button2Text = ReadText;
                    _view.Button3Text = UpdateText;
                    _view.Button4Text = DeleteText;
                    _view.Button1Visible = false;
                    _view.Button2Visible = _view.Button3Visible = _view.Button4Visible = true;
                } },
                { 15, ()=>
                {
                    _view.Button1Text = CreateText;
                    _view.Button2Text = ReadText;
                    _view.Button3Text = UpdateText;
                    _view.Button4Text = DeleteText;
                    _view.Button1Visible = _view.Button2Visible = _view.Button3Visible = _view.Button4Visible = true;
                } },

            };

            var binary = DoBinaryConversion();
            _view.BoolValue = binary;
            buttonMap[binary]();
        }

        private int DoBinaryConversion()
        {
            return (_view.CanCreate ? 1 : 0) + (_view.CanRead ? 2 : 0) + (_view.CanUpdate ? 4 : 0) + (_view.CanDelete ? 8 : 0);
        }

        public virtual void Create()
        {
            throw new NotImplementedException("Create method not implemented");
        }
        public virtual void Read()
        {
            throw new NotImplementedException("Read method not implemented");
        }
        public virtual void Update()
        {
            throw new NotImplementedException("Update method not implemented");
        }
        public virtual void Delete()
        {
            throw new NotImplementedException("Delete method not implemented");
        }

        public void Button1()
        {
            Create();
        }

        public void Button2()
        {
            var buttonSelect = new Dictionary<int, Action>
            {
                { 7, Create },
                { 11, Create },
                { 13, Create },
                { 14, Read },
                { 15, Read }
            };
            var binary = DoBinaryConversion();
            buttonSelect[binary]();
        }

        public void Button3()
        {
            var buttonSelect = new Dictionary<int, Action>
            {
                { 3, Create },
                { 5, Create },
                { 6, Read },
                { 7, Read },
                { 9, Create },
                { 10, Read },
                { 11, Read },
                { 12, Update },
                { 13, Update },
                { 14, Update },
                { 15, Update }
            };
            var binary = DoBinaryConversion();
            buttonSelect[binary]();
        }

        public void Button4()
        {
            var buttonSelect = new Dictionary<int, Action>
            {
                { 1, Create },
                { 2, Read },
                { 3, Read },
                { 4, Update },
                { 5, Update },
                { 6, Update },
                { 7, Update },
                { 8, Delete },
                { 9, Delete },
                { 10, Delete },
                { 11, Delete },
                { 12, Delete },
                { 13, Delete },
                { 14, Delete },
                { 15, Delete }
            };
            var binary = DoBinaryConversion();
            buttonSelect[binary]();
        }
    }
}
