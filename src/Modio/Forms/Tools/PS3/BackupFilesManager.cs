﻿using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using Humanizer;
using Modio.Database;
using Modio.Extensions;
using Modio.Forms.Windows;
using Modio.Models.Resources;
using System;
using System.Data;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace Modio.Forms.Tools.PS3
{
    public partial class BackupFilesManager : XtraForm
    {
        public BackupFilesManager()
        {
            InitializeComponent();
        }

        public ResourceManager Language = MainWindow.ResourceLanguage;

        private void BackupFilesManager_Load(object sender, EventArgs e)
        {
            Text = Language.GetString("BACKUP_FILES_MANAGER");
            GroupBackupFiles.Text = Language.GetString("BACKUP_FILES");

            ButtonEdit.SetControlText(Language.GetString("LABEL_EDIT"));
            ButtonDelete.SetControlText(Language.GetString("LABEL_DELETE"));
            ButtonDeleteAll.SetControlText(Language.GetString("LABEL_DELETE_ALL"));
            ButtonBackupFile.SetControlText(Language.GetString("LABEL_BACKUP_FILE"));
            ButtonRestoreFile.SetControlText(Language.GetString("LABEL_RESTORE_FILE"));

            LoadBackupFiles();
        }

        private void LoadBackupFiles()
        {
            GridBackupFiles.DataSource = null;

            DataTable dt = new();
            dt.Columns.Add(Language.GetString("LABEL_GAME_TITLE"), typeof(string));
            dt.Columns.Add(Language.GetString("LABEL_FILE_NAME"), typeof(string));
            dt.Columns.Add(Language.GetString("LABEL_FILE_SIZE"), typeof(string));
            dt.Columns.Add(Language.GetString("LABEL_CREATED_ON"), typeof(string));

            foreach (BackupFile backupFile in MainWindow.BackupFiles.BackupFiles)
            {
                long fileBytes = File.Exists(backupFile.LocalPath) ? new FileInfo(backupFile.LocalPath).Length : 0;

                dt.Rows.Add(MainWindow.Database.CategoriesData.GetCategoryById(backupFile.CategoryId).Title,
                    backupFile.FileName,
                    File.Exists(backupFile.LocalPath)
                        ? MainWindow.Settings.UseFormattedFileSizes ? fileBytes.Bytes().Humanize() : fileBytes + " " + Language.GetString("LABEL_BYTES")
                        : "No File Exists",
                    backupFile.CreatedDate.ToLocalTime());
            }

            GridBackupFiles.DataSource = dt;

            GridViewBackupFiles.Columns[0].Width = 200;
            GridViewBackupFiles.Columns[1].Width = 200;
            GridViewBackupFiles.Columns[2].Width = 125;
            GridViewBackupFiles.Columns[3].Width = 125;
        }

        private void GridViewBackupFiles_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            switch (GridViewBackupFiles.SelectedRowsCount)
            {
                case > 0:
                    try
                    {
                        BackupFile backupFile = MainWindow.BackupFiles.BackupFiles[GridViewBackupFiles.FocusedRowHandle];
                        Category category = MainWindow.Database.CategoriesData.GetCategoryById(backupFile.CategoryId);

                        long fileSize = File.Exists(backupFile.LocalPath) ? new FileInfo(backupFile.LocalPath).Length : 0;

                        LabelGameTitle.Text = category.Title;
                        LabelFileName.Text = backupFile.FileName;
                        LabelFileSize.Text = File.Exists(backupFile.LocalPath)
                            ? MainWindow.Settings.UseFormattedFileSizes ? fileSize.Bytes().Humanize()
                            : fileSize.ToString("{0:n}") + " " + Language.GetString("LABEL_BYTES")
                            : "No File Exists";
                        LabelCreatedOn.Text = backupFile.CreatedDate.ToLocalTime().ToString();
                        LabelLocalPath.Text = backupFile.LocalPath;
                        LabelInstallPath.Text = backupFile.InstallPath;


                        if (!File.Exists(backupFile.LocalPath))
                            XtraMessageBox.Show(
                                $"Local file: {backupFile.FileName} for game: {category.Title} can't be found at path: {backupFile.LocalPath}.\n\nIf you have moved this file then edit the backup and choose the locate the file, otherwise re-install your game update and backup the orginal game file again.",
                                "No Local File");
                    }
                    catch
                    {
                        // Will throw index out of range if deleting the last item
                    }

                    break;
            }

            ButtonEdit.Enabled = GridViewBackupFiles.SelectedRowsCount > 0;
            ButtonDelete.Enabled = GridViewBackupFiles.SelectedRowsCount > 0;
            ButtonDeleteAll.Enabled = GridViewBackupFiles.SelectedRowsCount > 0;
            ButtonBackupFile.Enabled = GridViewBackupFiles.SelectedRowsCount > 0 && MainWindow.IsConsoleConnected;
            ButtonRestoreFile.Enabled = GridViewBackupFiles.SelectedRowsCount > 0 && MainWindow.IsConsoleConnected;
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            int backupFileIndex = GridViewBackupFiles.FocusedRowHandle;

            BackupFile backupFile = MainWindow.BackupFiles.BackupFiles[backupFileIndex];

            BackupFile newBackupFile = DialogExtensions.ShowBackupFileDetails(this, backupFile);

            if (newBackupFile != null) MainWindow.BackupFiles.UpdateBackupFile(backupFileIndex, newBackupFile);

            LoadBackupFiles();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(this, "Do you really want to delete the selected item? This cannot be undone.",
                "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                MainWindow.BackupFiles.BackupFiles.RemoveAt(GridViewBackupFiles.FocusedRowHandle);
                LoadBackupFiles();
            }
        }

        private void ButtonDeleteAll_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(this,
                "Do you really want to delete all of the backup files? This cannot be undone.", "Delete All",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                MainWindow.BackupFiles.BackupFiles.Clear();
                LoadBackupFiles();
            }
        }

        private void ButtonBackupFile_Click(object sender, EventArgs e)
        {
            BackupFile backupFile = MainWindow.BackupFiles.BackupFiles[GridViewBackupFiles.FocusedRowHandle];
            BackupGameFile(backupFile);
        }

        private void ButtonRestoreFile_Click(object sender, EventArgs e)
        {
            BackupFile backupFile = MainWindow.BackupFiles.BackupFiles[GridViewBackupFiles.FocusedRowHandle];
            RestoreGameFile(backupFile);
        }

        /// <summary>
        /// </summary>
        /// <param name="backupFile"> </param>
        public void BackupGameFile(BackupFile backupFile)
        {
            try
            {
                MainWindow.FtpClient.DownloadFile(backupFile.LocalPath, backupFile.InstallPath);
                XtraMessageBox.Show(this, $"Successfully backed up file {backupFile.FileName} from {backupFile.InstallPath}.", Language.GetString("SUCCESS"));
            }
            catch (Exception ex)
            {
                Program.Log.Error(ex, $"Unable to backup game file. Error: {ex.Message}");
                XtraMessageBox.Show(this,
                    "There was a problem downloading the file. Make sure the file exists on your console.", Language.GetString("ERROR"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="backupFile"> </param>
        public void RestoreGameFile(BackupFile backupFile)
        {
            try
            {
                if (!File.Exists(backupFile.LocalPath))
                {
                    XtraMessageBox.Show(this,
                        "This file backup doesn't exist on your computer. If your game doesn't have mods installed, then I would suggest you backup the original files.",
                        "No File Found");
                    return;
                }

                FtpExtensions.UploadFile(backupFile.LocalPath, backupFile.InstallPath);
                XtraMessageBox.Show(
                    $"Successfully restored file: {backupFile.FileName} to path: {backupFile.InstallPath}",
                   Language.GetString("SUCCESS"));
            }
            catch (Exception ex)
            {
                Program.Log.Error(ex, "There was an issue attempting to restore file.");
                XtraMessageBox.Show(this,
                    "There was an issue restoring file. Make sure the local file exists on your computer.", Language.GetString("ERROR"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}