# Chrome 深色模式切換工具

這是一個可攜式 Windows 批次工具，將網頁內容與 Chrome 外觀切換為深色模式，也能還原成裝置預設外觀。

## 使用方式

1. 下載 `ChromeDarkMode.bat`。
2. 雙擊執行。
3. 輸入 `1` 啟用完整深色模式，或輸入 `2` 還原預設外觀。

執行時會先關閉所有 Chrome 視窗，再重新開啟 Chrome。請先保存尚未送出的表單或網頁內容。

## 特點

- 使用 Windows 內建 PowerShell，不需安裝額外軟體。
- 套用於同一 Windows 使用者下的現有 Chrome Profile。
- 訪客與新建立的 Profile 由 Chrome 深色啟動參數涵蓋。
- 還原時只移除本工具使用的深色 Flag，保留其他自訂 Chrome Flags。
- 不需要系統管理員權限，也不會寫入 Chrome 原則登錄機碼。

## 系統需求

- Windows 10 或 Windows 11
- Google Chrome
- Windows PowerShell 5.1 或更新版本

## 注意事項

Chrome 更新可能調整設定檔格式或深色模式參數。如果新版 Chrome 行為改變，請重新測試後再使用。
