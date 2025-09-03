; *** Inno Setup version 6.5.0+ Indonesian messages ***
;
; Translation by Azalea
;
; Maintained by Azalea (66keqing99@gmail.com)

[LangOptions]
LanguageName=Bahasa Indonesia
LanguageID=$0421
LanguageCodePage=1252

[Messages]

; *** Application titles
SetupAppTitle=Instalasi
SetupWindowTitle=Instalasi %1
UninstallAppTitle=Uninstal
UninstallAppFullTitle=Uninstal %1

; *** Misc. common
InformationTitle=Informasi
ConfirmTitle=Konfirmasi
ErrorTitle=Kesalahan

; *** SetupLdr messages
SetupLdrStartupMessage=Ini akan menginstal %1. Apakah Anda ingin melanjutkan?
LdrCannotCreateTemp=Tidak dapat membuat berkas sementara. Instalasi dibatalkan.
LdrCannotExecTemp=Tidak dapat menjalankan berkas di direktori sementara. Instalasi dibatalkan.

; *** Startup error messages
LastErrorMessage=%1.%n%nKesalahan %2: %3
SetupFileMissing=Berkas %1 tidak ditemukan. Harap perbaiki masalah atau dapatkan salinan baru dari program instalasi.
SetupFileCorrupt=Berkas instalasi rusak. Harap dapatkan salinan baru dari program instalasi.
SetupFileCorruptOrWrongVer=Berkas instalasi rusak, atau tidak kompatibel dengan versi instalasi ini. Harap perbaiki masalah atau dapatkan salinan baru dari program instalasi.
InvalidParameter=Parameter tidak valid diteruskan pada baris perintah:%n%n%1
SetupAlreadyRunning=Instalasi sudah berjalan.
WindowsVersionNotSupported=Program ini tidak mendukung versi Windows yang Anda jalankan.
WindowsServicePackRequired=Program ini memerlukan %1 Service Pack %2 atau yang lebih baru.
NotOnThisPlatform=Program ini tidak akan berjalan di %1.
OnlyOnThisPlatform=Program ini harus dijalankan di %1.
OnlyOnTheseArchitectures=Program ini hanya dapat diinstal pada versi Windows yang dirancang untuk arsitektur prosesor berikut:%n%n%1
WinVersionTooLowError=Program ini memerlukan %1 versi %2 atau yang lebih baru.
WinVersionTooHighError=Program ini tidak akan berjalan pada %1 versi %2 atau yang lebih baru.
AdminPrivilegesRequired=Anda harus masuk sebagai Administrator untuk menginstal program ini.
PowerUserPrivilegesRequired=Anda harus masuk sebagai Administrator atau sebagai anggota grup Power Users untuk menginstal program ini.
SetupAppRunningError=Instalasi mendeteksi bahwa %1 sedang berjalan.%n%nHarap tutup semua aplikasi lain sebelum melanjutkan. Klik OK untuk melanjutkan, atau Batal untuk keluar.
UninstallAppRunningError=Uninstal mendeteksi bahwa %1 sedang berjalan.%n%nHarap tutup semua aplikasi lain sebelum melanjutkan. Klik OK untuk melanjutkan, atau Batal untuk keluar.

; *** Startup questions
PrivilegesRequiredOverrideTitle=Pilih Mode Instalasi
PrivilegesRequiredOverrideInstruction=Pilih mode instalasi
PrivilegesRequiredOverrideText1=%1 dapat diinstal untuk semua pengguna (memerlukan hak administratif), atau hanya untuk Anda.
PrivilegesRequiredOverrideText2=%1 dapat diinstal hanya untuk Anda, atau untuk semua pengguna (memerlukan hak administratif).
PrivilegesRequiredOverrideAllUsers=Instal untuk semua pengguna (&A)
PrivilegesRequiredOverrideAllUsersRecommended=Instal untuk semua pengguna (&A) (disarankan)
PrivilegesRequiredOverrideCurrentUser=Instal hanya untuk saya (&M)
PrivilegesRequiredOverrideCurrentUserRecommended=Instal hanya untuk saya (&M) (disarankan)

; *** Misc. errors
ErrorCreatingDir=Terjadi kesalahan saat mencoba membuat direktori: %1
ErrorTooManyFilesInDir=Terjadi kesalahan saat mencoba membuat berkas di direktori tujuan: Terlalu banyak berkas di direktori

; *** Setup common messages
ExitSetupTitle=Keluar dari Instalasi
ExitSetupMessage=Instalasi belum selesai. Jika Anda keluar sekarang, program tidak akan diinstal.%n%nAnda dapat menjalankan instalasi lagi di lain waktu untuk menyelesaikan instalasi.%n%nKeluar dari instalasi?
AboutSetupMenuItem=Tentang Instalasi (&A)...
AboutSetupTitle=Tentang Instalasi
AboutSetupMessage=%1 versi %2%n%3%n%n%1 beranda:%n%4
AboutSetupNote=
TranslatorNote=

; *** Buttons
ButtonBack=< Kembali (&B)
ButtonNext=Lanjut (&N) >
ButtonInstall=Instal (&I)
ButtonOK=OK
ButtonCancel=Batal
ButtonYes=Ya (&Y)
ButtonYesToAll=Ya untuk Semua (&A)
ButtonNo=Tidak (&N)
ButtonNoToAll=Tidak untuk Semua (&O)
ButtonFinish=Selesai (&F)
ButtonBrowse=Jelajahi (&B)...
ButtonWizardBrowse=Jelajahi (&R)...
ButtonNewFolder=Buat Folder Baru (&M)

; *** "Select Language" dialog messages
SelectLanguageTitle=Pilih Bahasa Instalasi
SelectLanguageLabel=Pilih bahasa yang akan digunakan selama instalasi.

; *** Common wizard text
ClickNext=Klik Lanjut untuk melanjutkan, atau Batal untuk keluar dari Instalasi.
BeveledLabel=
BrowseDialogTitle=Jelajahi Folder
BrowseDialogLabel=Pilih folder dari daftar di bawah ini, lalu klik OK.
NewFolderName=Folder Baru

; *** "Welcome" wizard page
WelcomeLabel1=Selamat datang di Wizard Instalasi [name]
WelcomeLabel2=Ini akan menginstal [name/ver] di komputer Anda.%n%nDisarankan agar Anda menutup semua aplikasi lain sebelum melanjutkan.

; *** "Password" wizard page
WizardPassword=Kata Sandi
PasswordLabel1=Program instalasi ini dilindungi kata sandi.
PasswordLabel3=Harap masukkan kata sandi, lalu klik Lanjut. Kata sandi peka terhadap huruf besar/kecil.
PasswordEditLabel=Kata Sandi (&P):
IncorrectPassword=Kata sandi yang Anda masukkan salah. Harap coba lagi.

; *** "License Agreement" wizard page
WizardLicense=Perjanjian Lisensi
LicenseLabel=Harap baca informasi penting berikut sebelum melanjutkan.
LicenseLabel3=Harap baca perjanjian lisensi berikut. Anda harus menerima persyaratan perjanjian ini sebelum melanjutkan instalasi.
LicenseAccepted=Saya menerima perjanjian (&A)
LicenseNotAccepted=Saya tidak menerima perjanjian (&D)

; *** "Information" wizard pages
WizardInfoBefore=Informasi
InfoBeforeLabel=Harap baca informasi penting berikut sebelum melanjutkan.
InfoBeforeClickLabel=Klik Lanjut untuk melanjutkan.
WizardInfoAfter=Informasi
InfoAfterLabel=Harap baca informasi penting berikut sebelum melanjutkan.
InfoAfterClickLabel=Klik Lanjut untuk melanjutkan.

; *** "User Information" wizard page
WizardUserInfo=Informasi Pengguna
UserInfoDesc=Harap masukkan informasi Anda.
UserInfoName=Nama Pengguna (&U):
UserInfoOrg=Organisasi (&O):
UserInfoSerial=Nomor Seri (&S):
UserInfoNameRequired=Anda harus memasukkan nama pengguna.

; *** "Select Destination Location" wizard page
WizardSelectDir=Pilih Lokasi Tujuan
SelectDirDesc=Di mana [name] harus diinstal?
SelectDirLabel3=Instalasi akan menginstal [name] ke dalam folder berikut.
SelectDirBrowseLabel=Untuk melanjutkan, klik Lanjut. Jika Anda ingin memilih folder yang berbeda, klik Jelajahi.
DiskSpaceGBLabel=Program ini memerlukan setidaknya [gb] GB ruang disk kosong.
DiskSpaceMBLabel=Program ini memerlukan setidaknya [mb] MB ruang disk kosong.
CannotInstallToNetworkDrive=Tidak dapat menginstal ke drive jaringan.
CannotInstallToUNCPath=Tidak dapat menginstal ke jalur UNC.
InvalidPath=Anda harus memasukkan path lengkap dengan huruf drive, misalnya:%n%nC:\APP%n%natau path UNC, misalnya:%n%n\\server\share
InvalidDrive=Drive atau path UNC yang Anda pilih tidak ada atau tidak dapat diakses. Harap pilih yang lain.
DiskSpaceWarningTitle=Ruang Disk Tidak Cukup
DiskSpaceWarning=Instalasi memerlukan setidaknya %1 KB ruang disk kosong, tetapi drive yang dipilih hanya memiliki %2 KB ruang kosong.%n%nApakah Anda ingin melanjutkan?
DirNameTooLong=Nama direktori atau path terlalu panjang.
InvalidDirName=Nama folder tidak valid.
BadDirName32=Nama folder tidak boleh berisi karakter berikut:%n%n%1
DirExistsTitle=Folder Sudah Ada
DirExists=Folder:%n%n%1%n%nsudah ada. Apakah Anda ingin menginstal ke folder itu?
DirDoesntExistTitle=Folder Tidak Ada
DirDoesntExist=Folder:%n%n%1%n%ntidak ada. Apakah Anda ingin membuatnya?

; *** "Select Components" wizard page
WizardSelectComponents=Pilih Komponen
SelectComponentsDesc=Pilih komponen mana yang ingin Anda instal.
SelectComponentsLabel2=Pilih komponen yang ingin Anda instal; hapus centang komponen yang tidak ingin Anda instal. Klik Lanjut saat Anda siap untuk melanjutkan.
FullInstallation=Instalasi Penuh
; if possible don't translate 'Compact' as 'Minimal' (I mean 'Minimal' in your language)
CompactInstallation=Instalasi Ringkas
CustomInstallation=Instalasi Kustom
NoUninstallWarningTitle=Komponen Sudah Ada
NoUninstallWarning=Instalasi telah mendeteksi bahwa komponen berikut tampaknya sudah diinstal di komputer Anda:%n%n%1%n%nMembatalkan pilihan komponen-komponen ini tidak akan menghapusnya.%n%nApakah Anda ingin melanjutkan?
ComponentSize1=%1 KB
ComponentSize2=%1 MB
ComponentsDiskSpaceGBLabel=Pilihan saat ini memerlukan setidaknya [gb] GB ruang disk kosong.
ComponentsDiskSpaceMBLabel=Pilihan saat ini memerlukan setidaknya [mb] MB ruang disk kosong.

; *** "Select Additional Tasks" wizard page
WizardSelectTasks=Pilih Tugas Tambahan
SelectTasksDesc=Tugas tambahan mana yang harus dilakukan?
SelectTasksLabel2=Pilih tugas tambahan yang ingin Anda lakukan saat menginstal [name], lalu klik Lanjut.

; *** "Select Start Menu Folder" wizard page
WizardSelectProgramGroup=Pilih Folder Start Menu
SelectStartMenuFolderDesc=Di mana Instalasi harus menempatkan pintasan program?
SelectStartMenuFolderLabel3=Instalasi akan membuat pintasan program di folder Start Menu berikut.
SelectStartMenuFolderBrowseLabel=Untuk melanjutkan, klik Lanjut. Jika Anda ingin memilih folder yang berbeda, klik Jelajahi.
MustEnterGroupName=Anda harus memasukkan nama folder.
GroupNameTooLong=Nama folder atau path terlalu panjang.
InvalidGroupName=Nama folder tidak valid.
BadGroupName=Nama folder tidak boleh berisi karakter berikut:%n%n%1
NoProgramGroupCheck2=Jangan buat folder Start Menu (&D)

; *** "Ready to Install" wizard page
WizardReady=Siap untuk Menginstal
ReadyLabel1=Instalasi sekarang siap untuk memulai menginstal [name] di komputer Anda.
ReadyLabel2a=Klik Instal untuk melanjutkan instalasi ini, atau klik Kembali jika Anda ingin meninjau atau mengubah pengaturan apa pun.
ReadyLabel2b=Klik Instal untuk melanjutkan instalasi ini.
ReadyMemoUserInfo=Informasi Pengguna:
ReadyMemoDir=Lokasi Tujuan:
ReadyMemoType=Jenis Instalasi:
ReadyMemoComponents=Komponen yang Dipilih:
ReadyMemoGroup=Folder Start Menu:
ReadyMemoTasks=Tugas Tambahan:

; *** TDownloadWizardPage wizard page and DownloadTemporaryFile
DownloadingLabel2=Mengunduh berkas...
ButtonStopDownload=Hentikan Unduhan (&S)
StopDownload=Apakah Anda yakin ingin membatalkan unduhan?
ErrorDownloadAborted=Unduhan dibatalkan
ErrorDownloadFailed=Gagal mengunduh: %1 %2
ErrorDownloadSizeFailed=Gagal mendapatkan ukuran: %1 %2
ErrorProgress=Progres tidak valid: %1 / %2
ErrorFileSize=Ukuran berkas tidak valid: diharapkan %1, aktual %2

; *** TExtractionWizardPage wizard page and ExtractArchive
ExtractingLabel=Mengekstrak berkas...
ButtonStopExtraction=Hentikan Ekstraksi (&S)
StopExtraction=Apakah Anda yakin ingin membatalkan ekstraksi?
ErrorExtractionAborted=Ekstraksi dibatalkan
ErrorExtractionFailed=Gagal mengekstrak: %1

; *** Archive extraction failure details
ArchiveIncorrectPassword=Kata sandi salah
ArchiveIsCorrupted=Arsip rusak
ArchiveUnsupportedFormat=Format arsip tidak didukung

; *** "Preparing to Install" wizard page
WizardPreparing=Mempersiapkan Instalasi
PreparingDesc=Instalasi sedang mempersiapkan untuk menginstal [name] di komputer Anda.
PreviousInstallNotCompleted=Instalasi atau uninstalasi sebelumnya dari aplikasi ini belum selesai. Anda harus me-restart komputer Anda untuk menyelesaikannya.%n%nSetelah me-restart, jalankan Instalasi lagi untuk menyelesaikan instalasi [name].
CannotContinue=Instalasi tidak dapat dilanjutkan. Klik Batal untuk keluar.
ApplicationsFound=Aplikasi berikut menggunakan berkas yang perlu diperbarui oleh Instalasi. Disarankan agar Anda mengizinkan Instalasi untuk menutupnya secara otomatis.
ApplicationsFound2=Aplikasi berikut menggunakan berkas yang perlu diperbarui oleh Instalasi. Disarankan agar Anda mengizinkan Instalasi untuk menutupnya secara otomatis. Setelah instalasi selesai, Instalasi akan mencoba untuk me-restart aplikasi.
CloseApplications=Tutup aplikasi secara otomatis (&A)
DontCloseApplications=Jangan tutup aplikasi (&D)
ErrorCloseApplications=Instalasi tidak dapat menutup semua aplikasi secara otomatis. Disarankan agar Anda menutup semua aplikasi yang menggunakan berkas yang perlu diperbarui oleh Instalasi sebelum melanjutkan.
PrepareToInstallNeedsRestart=Instalasi harus me-restart komputer Anda. Setelah di-restart, jalankan Instalasi lagi untuk menyelesaikan instalasi [name].%n%nApakah Anda ingin me-restart sekarang?

; *** "Installing" wizard page
WizardInstalling=Menginstal
InstallingLabel=Harap tunggu sementara Instalasi menginstal [name] di komputer Anda.

; *** "Setup Completed" wizard page
FinishedHeadingLabel=Menyelesaikan Wizard Instalasi [name]
FinishedLabelNoIcons=[name] telah diinstal di komputer Anda.
FinishedLabel=[name] telah diinstal di komputer Anda. Klik pintasan yang diinstal untuk meluncurkan aplikasi.
ClickFinish=Klik Selesai untuk keluar dari Instalasi.
FinishedRestartLabel=Untuk menyelesaikan instalasi [name], komputer Anda harus di-restart. Apakah Anda ingin me-restart sekarang?
FinishedRestartMessage=Untuk menyelesaikan instalasi [name], komputer Anda harus di-restart.%n%nApakah Anda ingin me-restart sekarang?
ShowReadmeCheck=Lihat berkas README
YesRadio=Ya, restart komputer sekarang (&Y)
NoRadio=Tidak, saya akan me-restart komputer nanti (&N)
; used for example as 'Run MyProg.exe'
RunEntryExec=Jalankan %1
; used for example as 'View Readme.txt'
RunEntryShellExec=Lihat %1

; *** "Setup Needs the Next Disk" stuff
ChangeDiskTitle=Instalasi Membutuhkan Disk Berikutnya
SelectDiskLabel2=Harap masukkan Disk %1 dan klik OK.%n%nJika berkas di disk ini tidak dapat ditemukan di folder yang ditunjukkan di bawah, masukkan path yang benar atau klik Jelajahi.
PathLabel=Path (&P):
FileNotInDir2=Berkas "%1" tidak dapat ditemukan di "%2". Harap masukkan disk yang benar atau pilih folder lain.
SelectDirectoryLabel=Harap tentukan lokasi disk berikutnya.

; *** Installation phase messages
SetupAborted=Instalasi tidak selesai.%n%nHarap perbaiki masalah dan jalankan Instalasi lagi.
AbortRetryIgnoreSelectAction=Pilih tindakan
AbortRetryIgnoreRetry=Coba lagi (&T)
AbortRetryIgnoreIgnore=Abaikan kesalahan dan lanjutkan (&I)
AbortRetryIgnoreCancel=Batalkan instalasi
RetryCancelSelectAction=Pilih tindakan
RetryCancelRetry=Coba lagi (&T)
RetryCancelCancel=Batal

; *** Installation status messages
StatusClosingApplications=Menutup aplikasi...
StatusCreateDirs=Membuat direktori...
StatusExtractFiles=Mengekstrak berkas...
StatusDownloadFiles=Mengunduh berkas...
StatusCreateIcons=Membuat pintasan...
StatusCreateIniEntries=Membuat entri INI...
StatusCreateRegistryEntries=Membuat entri registri...
StatusRegisterFiles=Mendaftarkan berkas...
StatusSavingUninstall=Menyimpan informasi uninstal...
StatusRunProgram=Menyelesaikan instalasi...
StatusRestartingApplications=Me-restart aplikasi...
StatusRollback=Mengembalikan perubahan...

; *** Misc. errors
ErrorInternal2=Kesalahan internal: %1
ErrorFunctionFailedNoCode=Kesalahan %1
ErrorFunctionFailed=Kesalahan %1; kode %2
ErrorFunctionFailedWithMessage=Kesalahan %1; kode %2.%n%3
ErrorExecutingProgram=Tidak dapat menjalankan berkas:%n%1

; *** Registry errors
ErrorRegOpenKey=Kesalahan saat membuka kunci registri:%n%1\%2
ErrorRegCreateKey=Kesalahan saat membuat kunci registri:%n%1\%2
ErrorRegWriteKey=Kesalahan saat menulis ke kunci registri:%n%1\%2

; *** INI errors
ErrorIniEntry=Kesalahan saat membuat entri INI di berkas %1.

; *** File copying errors
FileAbortRetryIgnoreSkipNotRecommended=Lewati berkas ini (&S) (tidak disarankan)
FileAbortRetryIgnoreIgnoreNotRecommended=Abaikan kesalahan dan lanjutkan (&I) (tidak disarankan)
SourceIsCorrupted=Berkas sumber rusak
SourceDoesntExist=Berkas sumber "%1" tidak ada
SourceVerificationFailed=Verifikasi berkas sumber gagal: %1
VerificationSignatureDoesntExist=Berkas tanda tangan "%1" tidak ada
VerificationSignatureInvalid=Berkas tanda tangan "%1" tidak valid
VerificationKeyNotFound=Kunci yang tidak diketahui digunakan dalam berkas tanda tangan "%1"
VerificationFileNameIncorrect=Nama berkas salah
VerificationFileTagIncorrect=Tag berkas salah
VerificationFileSizeIncorrect=Ukuran berkas salah
VerificationFileHashIncorrect=Hash berkas salah
ExistingFileReadOnly2=Berkas yang ada ditandai sebagai hanya-baca. Tidak dapat diganti.
ExistingFileReadOnlyRetry=Hapus atribut hanya-baca dan coba lagi (&R)
ExistingFileReadOnlyKeepExisting=Simpan berkas yang ada (&K)
ErrorReadingExistingDest=Terjadi kesalahan saat membaca berkas tujuan yang ada:
FileExistsSelectAction=Pilih tindakan
FileExists2=Berkas sudah ada.
FileExistsOverwriteExisting=Timpa berkas yang ada (&O)
FileExistsKeepExisting=Simpan berkas yang ada (&K)
FileExistsOverwriteOrKeepAll=Lakukan ini untuk konflik berikutnya (&D)
ExistingFileNewerSelectAction=Pilih tindakan
ExistingFileNewer2=Berkas yang ada lebih baru dari yang coba diinstal oleh Instalasi.
ExistingFileNewerOverwriteExisting=Timpa berkas yang ada (&O)
ExistingFileNewerKeepExisting=Simpan berkas yang ada (&K) (disarankan)
ExistingFileNewerOverwriteOrKeepAll=Lakukan ini untuk konflik berikutnya (&D)
ErrorChangingAttr=Terjadi kesalahan saat mencoba mengubah atribut berkas yang ada:
ErrorCreatingTemp=Terjadi kesalahan saat mencoba membuat berkas di folder tujuan:
ErrorReadingSource=Terjadi kesalahan saat membaca berkas sumber:
ErrorCopying=Terjadi kesalahan saat menyalin berkas:
ErrorDownloading=Terjadi kesalahan saat mengunduh berkas:
ErrorExtracting=Terjadi kesalahan saat mengekstrak arsip:
ErrorReplacingExistingFile=Terjadi kesalahan saat mengganti berkas yang ada:
ErrorRestartReplace=Gagal melakukan penggantian saat restart:
ErrorRenamingTemp=Terjadi kesalahan saat mengganti nama berkas di folder tujuan:
ErrorRegisterServer=Gagal mendaftarkan DLL/OCX: %1
ErrorRegSvr32Failed=RegSvr32 gagal dengan kode keluar %1
ErrorRegisterTypeLib=Gagal mendaftarkan pustaka tipe: %1

; *** Uninstall display name markings
UninstallDisplayNameMark=%1 (%2)
UninstallDisplayNameMarks=%1 (%2, %3)
UninstallDisplayNameMark32Bit=32-bit
UninstallDisplayNameMark64Bit=64-bit
UninstallDisplayNameMarkAllUsers=semua pengguna
UninstallDisplayNameMarkCurrentUser=pengguna saat ini

; *** Post-installation errors
ErrorOpeningReadme=Gagal membuka berkas README.
ErrorRestartingComputer=Instalasi gagal me-restart komputer. Harap lakukan secara manual.

; *** Uninstaller messages
UninstallNotFound=Berkas "%1" tidak ditemukan. Tidak dapat menghapus instalasi.
UninstallOpenError=Berkas "%1" tidak dapat dibuka. Tidak dapat menghapus instalasi.
UninstallUnsupportedVer=Log uninstal "%1" dalam format yang tidak dikenal oleh versi uninstaller ini. Tidak dapat menghapus instalasi.
UninstallUnknownEntry=Entri yang tidak dikenal (%1) ditemukan di log uninstal.
ConfirmUninstall=Apakah Anda yakin ingin menghapus %1 dan semua komponennya sepenuhnya?
UninstallOnlyOnWin64=Program ini hanya dapat dihapus instalasinya saat berjalan di Windows 64-bit.
OnlyAdminCanUninstall=Program ini hanya dapat dihapus instalasinya oleh seseorang dengan hak administratif.
UninstallStatusLabel=Harap tunggu sementara %1 dihapus dari komputer Anda.
UninstalledAll=%1 berhasil dihapus dari komputer Anda.
UninstalledMost=Uninstal %1 selesai.%n%nBeberapa elemen tidak dapat dihapus. Anda mungkin harus menghapusnya secara manual.
UninstalledAndNeedsRestart=Untuk menyelesaikan uninstalasi %1, komputer Anda harus di-restart. Apakah Anda ingin me-restart sekarang?
UninstallDataCorrupted=Berkas "%1" rusak. Tidak dapat menghapus instalasi.

; *** Uninstallation phase messages
ConfirmDeleteSharedFileTitle=Hapus Berkas Bersama?
ConfirmDeleteSharedFile2=Sistem menunjukkan bahwa berkas bersama berikut tidak lagi digunakan oleh program apa pun. Apakah Anda ingin menghapus berkas bersama ini?%n%nJika ada program yang masih menggunakan berkas ini dan dihapus, program tersebut mungkin tidak berfungsi dengan baik. Jika Anda tidak yakin, pilih Tidak. Membiarkan berkas di sistem Anda tidak akan membahayakan.
SharedFileNameLabel=Nama berkas:
SharedFileLocationLabel=Lokasi:
WizardUninstalling=Status Uninstal
StatusUninstalling=Menghapus instalasi %1...

; *** Shutdown block reasons
ShutdownBlockReasonInstallingApp=Menginstal %1.
ShutdownBlockReasonUninstallingApp=Menghapus instalasi %1.

; The custom messages below aren't used by Setup itself, but if you make
; use of them in your scripts, you'll want to translate them.

[CustomMessages]

NameAndVersion=%1 versi %2
AdditionalIcons=Ikon tambahan:
CreateDesktopIcon=Buat ikon di desktop (&D)
CreateQuickLaunchIcon=Buat ikon Quick Launch (&Q)
ProgramOnTheWeb=%1 di Web
UninstallProgram=Uninstal %1
LaunchProgram=Jalankan %1
AssocFileExtension=Kaitkan %1 dengan ekstensi berkas %2
AssocingFileExtension=Mengaitkan %1 dengan ekstensi berkas %2...
AutoStartProgramGroupDescription=Startup:
AutoStartProgram=Mulai %1 secara otomatis
AddonHostProgramNotFound=%1 tidak dapat ditemukan di folder yang dipilih.%n%nLanjutkan?