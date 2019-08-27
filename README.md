# 欢迎来到《幻想空奕行 ~ Choice of the Future》的源代码仓库。

# 这里就是项目文件夹，直接使用unity把这个文件夹打开就可以了，其中，Docs是开发档案，很多细则都写在里面了，可以随时观看。

学会使用unity之后，就可以愉快的开始开发了~

当然了，协同开发少不了标准的制定，下面是开发的规则，请开发之前仔细的阅读：
	1.所有文件、文件夹的命名规则：
	（1）英文名命名，描述这个文件（文件夹）的内容，尽量能让其他人看得懂，可以由多个单词/数字组合而来，比方说第一个单词是性质（Image，Button。Text等），然后（选择性的）加“Of”再加其所属。组合规则：每个单词的第一个字母大写，需要全部大写的专有名词保持全部大写，如：ImageOfPlayer（角色的图像）、UIImagesOfBackpack（背包的UI图像）、ButtonOfGameStart（游戏开始的按键）
	（2）路径中不能出现任何中文
	（3）文件的另一个版本的命名格式为“原版文件名_注释”(其中注释的命名规则同（1）)。如：LoadingImage.png这张图片的白色版本为LoadingImage_White

	2.程序里类的成员变量的定义：先public，后private，其中，将获取的游戏实例（例：Rigidbody2D、GameObject类型的变量）放在前面，普通变量放在后面（如speed，position）。

	3.程序里的变量使用驼峰起名法（什么意思自己百度），函数名同第二条。

	4.代码格式如果不知道怎么写的话使用自动格式化（很多IDE都有，实在不行去用visual stdio），代码风格不要求完全统一但是需要让别人看懂你的代码（debug的时候有可能需要别人帮忙）。

	5.程序中严禁使用绝对路径寻找资源，因为别人的电脑可没这个路径。

	6.使用Git进行协同开发，不会的话参考此教程：
	https://www.liaoxuefeng.com/wiki/896043488029600/896827951938304（Git的使用）
	https://www.jianshu.com/p/8c69d1021d98（多人协作开发Git）
	源代码已经放在这里了：https://github.com/Phantasm-inside-a-Game-Unity-Team/Phantasm-inside-a-Game-Choice-of-the-Future
	除此之外有什么不明白的地方请及时联系

除此之外，还有项目的结构需要注意，各种文件的存放规则，文件命名的详细规则见Docs目录下的“工程目录.docx”文件

有什么拿不准的，还请来讨论一下在做决定

以上

制作组人员：
freesia