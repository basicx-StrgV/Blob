using System;
using System.Threading.Tasks;

namespace Blob
{
    class Renderer
    {
        private Task _rendering;

        private bool _run = false;

        private readonly int _startRow;
        private readonly int _endRow;

        private readonly string _emptyField = "▓▓";//▓▓
        private readonly string _setField = "▒▒";//▒▒

        public Renderer()
        {
            _startRow = Console.CursorTop + 1;
            _endRow = _startRow + Fields.Blob.Length;
        }

        public void Start()
        {
            _run = true;
            _rendering = Task.Run(() => Rendering());
        }

        public void Stop()
        {
            _run = false;
            _rendering.Wait();
            _rendering.Dispose();
        }

        private void Rendering()
        {
            while (_run)
            {
                int tempRow = _startRow;
                for (int i = 0; i < Fields.Blob.Length; i++)
                {
                    Console.SetCursorPosition(0, tempRow);
                    for (int j = 0; j < Fields.Blob[i].Length; j++)
                    {
                        switch (Fields.Blob[i][j])
                        {
                            case 0:
                                Console.Write(_emptyField);
                                break;
                            case 1:
                                Console.Write(_setField);
                                break;
                        }
                    }
                    switch (tempRow + 1 < _endRow)
                    {
                        case true:
                            tempRow++;
                            break;
                        case false:
                            tempRow = _startRow;
                            break;
                    }
                }
            }
        }
    }
}
