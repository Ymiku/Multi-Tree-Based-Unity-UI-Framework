#Unity Multi-Tree-Based-UIFramework
A simple uiFramework for UGUI

<img src=http://chuantu.biz/t5/35/1475049580x3690160064.png />

How to use:

UIManager.Pop()  return to last UI

UIManager.Push() Enter new UI

UIManager.Instance.StartAndResetUILine Enter a UITree and reset it

UIManager.Instance.StartUILine  Enter a UITree and back to last status

每个ui都有3个状态：暂停 进入 退出

每个ui都包含4个函数 OnEnter OnPause OnResume OnExit来控制状态的改变

一般情况下，暂停状态时，把canvasgroup的射线检测关掉

退出时SetActive(false)

Uimanager用来进行创建销毁ui

而UI的数据状态存储在ContextManger这个单例的一个Stack中

开启新ui时 push，退出当前ui时 pop，返回到栈顶ui


在此框架中，UI的结构并不是一个树，而是多个树

而我的游戏UI树可分为    1进入游戏前的树   2游戏中的树

如图：

 


主界面和关卡选择即为顶层节点

而每棵树都存在一个节点可以进行树的转换

比如在关卡选择里，我们选择了关卡，进入关卡，ui树就从进入游戏前的树转到了游戏中的树

相应的，由于有了多个树的概念，那么自然，contextmanager也就不能作为一个单例存在了，

在我的框架里，每一个树类似于状态机的一个状态，而与状态机不同，老的状态不会销毁，而是会保存起来，当从新的UI树转回老的UI树时，我们就可以取得老ui树转换前的状态

以下是选择关卡后的ui操作

UIManager.Instance.StartAndResetUILine (UIManager.UILine.LevelMenu);
                UIManager.Instance.Push (new LevelOptionContext ()); 

这是从关卡中返回关卡选择界面的ui操作

UIManager.Instance.StartUILine (UIManager.UILine.MainMenu); 

 

这样就解决了原框架需要多次pop和push的问题，如果ui的层次复杂时，会更加方便

此外，我添加了淡入淡出的效果

思路就是把淡出期间的操作存到一个队列中，淡出完毕后再依次执行



使用方法和原框架差不多，可以看这里https://github.com/MrNerverDie/Unity-UI-Framework

但是增加了UILine这个枚举，想定义多少个树，就定义多少枚举

使用StartUILine 进入目标UI树并回到之前状态

StartAndResetUILine进入目标UI树并清空状态
