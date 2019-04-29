# Sedentary-reminder 久坐提醒小工具
> **如若对您有用，请点个star, 万分感激！**  
>
> [百度网盘下载](https://pan.baidu.com/s/1KZEPBBQkF_IpGgZplSXlYQ). 提取码：0iza

> * 2019/04/29更新：
>
>   > 1. 修复长时间运行后内存占用过高的重大BUG，之前失误多写了一段代码，导致这个问题。。。这个问题出现的太弱智了。。。
>   >
>   > 2. 增加了工作计时窗体可拖动功能
>
> * 2019/04/28更新：增加“即将休息”提示信息，更改了工作倒计时背景色，修复一些小问题，重置了百度网盘下载链接。
>
> * 2019/04/27更新：修复了锁定时时间显示不对的问题。


> ![](https://github.com/wjbgis/Sedentary-reminder/blob/master/ScreenShot/0.png)
>
> ​	偶然看到人民日报公众号这篇文章，如果数字相对准确，那确实有点震惊。感觉自己明知久坐有害，但就是不自觉，电脑前一坐就是一上午、一下午。于是就想是否有一款软件能定时提醒自己不要久坐，网上搜寻了半天，感觉找到的软件都不能“完全阻止”我久坐的行为，那干脆自己写一个算了。

---

* 主界面很简单，也很丑，用的WinForm

  ![](https://github.com/wjbgis/Sedentary-reminder/blob/master/ScreenShot/1.png)

* 点击`开始`之后就开始倒计时

  ![](https://github.com/wjbgis/Sedentary-reminder/blob/master/ScreenShot/2.1.png)

* 工作倒计时剩余15秒时，提示用户即将锁定输入

  ![](https://github.com/wjbgis/Sedentary-reminder/blob/master/ScreenShot/4.png)

* 倒计时结束，显示遮罩层，屏蔽鼠标、键盘（为防止意外，未屏蔽`ctrl`+`alt`+`del`组合按键，可通过该组合键关机，但无法使用任务管理器）

  ![](https://github.com/wjbgis/Sedentary-reminder/blob/master/ScreenShot/3.png)
  
* 休息结束，继续开始工作倒计时

* **支持系统：Win7/10**

