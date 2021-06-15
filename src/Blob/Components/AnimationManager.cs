namespace Blob
{
    class AnimationManager
    {
        public void NoBlobMouth()
        {
            for (int i = 15; i <= 18; i++)
            {
                for (int j = 11; j <= 18; j++)
                {
                    Fields.Blob[i][j] = 1;
                }
            }
        }

        public void SmallBlobMouth()
        {
            //Remove old mouth
            for (int i = 15; i <= 18; i++)
            {
                for (int j = 11; j <= 18; j++)
                {
                    Fields.Blob[i][j] = 1;
                }
            }
            //Add new mouth
            for (int i = 15; i <= 18; i++)
            {
                for (int j = 0; j < Fields.Blob[i].Length; j++)
                {
                    if ((i == 16 && (j >= 13 && j <= 16)))
                    {
                        Fields.Blob[i][j] = 0;
                    }
                }
            }
        }

        public void MiddleBlobMouth()
        {
            //Remove old mouth
            for (int i = 15; i <= 18; i++)
            {
                for (int j = 11; j <= 18; j++)
                {
                    Fields.Blob[i][j] = 1;
                }
            }
            //Add new mouth
            for (int i = 15; i <= 18; i++)
            {
                for (int j = 0; j < Fields.Blob[i].Length; j++)
                {
                    if ((i == 16 && (j >= 11 && j <= 18)) ||
                        (i == 17 && (j >= 12 && j <= 17))
                       )
                    {
                        Fields.Blob[i][j] = 0;
                    }
                }
            }
        }

        public void HappyBlobMouth()
        {
            //Remove old mouth
            for (int i = 15; i <= 18; i++)
            {
                for (int j = 11; j <= 18 ; j++)
                {
                    Fields.Blob[i][j] = 1;
                }
            }
            //Add new mouth
            for (int i = 15; i <= 18; i++)
            {
                for (int j = 0; j < Fields.Blob[i].Length; j++)
                {
                    if ((i == 15 && (j >= 11 && j <= 18)) ||
                        (i == 16 && (j >= 11 && j <= 18)) ||
                        (i == 17 && (j >= 12 && j <= 17)) ||
                        (i == 18 && (j >= 13 && j <= 16))
                       )
                    {
                        Fields.Blob[i][j] = 0;
                    }
                }
            }
        }

        public void BlobEyesToLeft()
        {
            //Remove old eye points
            Fields.Blob[10][10] = 1;
            Fields.Blob[10][20] = 1;
            //Add new eye points
            Fields.Blob[10][9] = 0;
            Fields.Blob[10][19] = 0;
        }

        public void BlobEyesToRight()
        {
            //Remove old eye points
            Fields.Blob[10][9] = 1;
            Fields.Blob[10][19] = 1;
            //Add new eye points
            Fields.Blob[10][10] = 0;
            Fields.Blob[10][20] = 0;
        }

        public void BlobAntenaUp()
        {
            //Remove old antena part
            Fields.Blob[4][4] = 0;
            Fields.Blob[4][25] = 0;
            //Add new antena part
            Fields.Blob[3][3] = 1;
            Fields.Blob[3][26] = 1;
        }

        public void BlobAntenaDown()
        {
            //Remove old antena part
            Fields.Blob[3][3] = 0;
            Fields.Blob[3][26] = 0;
            //Add new antena part
            Fields.Blob[4][4] = 1;
            Fields.Blob[4][25] = 1;
        }
    }
}
