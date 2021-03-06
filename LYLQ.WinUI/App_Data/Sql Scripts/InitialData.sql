DECLARE @departmentNumber INT 
SELECT  @departmentNumber = COUNT(*) FROM [dbo].[Department] 
IF(@departmentNumber = 0)
BEGIN
	INSERT INTO [dbo].[Department] ([Code], [Name], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Type]) VALUES (N'13502', N'本部', N'admin', N'2015-10-03 10:33:28', N'admin', N'2015-10-03 10:33:28', 0)
	INSERT INTO [dbo].[Department] ([Code], [Name], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Type]) VALUES (N'13504', N'新城支行', N'admin', N'2015-08-31 18:15:47', N'admin', N'2015-08-31 18:15:47', 1)
	INSERT INTO [dbo].[Department] ([Code], [Name], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Type]) VALUES (N'13507', N'池江支行', N'admin', N'2015-08-31 18:22:06', N'admin', N'2015-08-31 18:22:06', 1)
	INSERT INTO [dbo].[Department] ([Code], [Name], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Type]) VALUES (N'13508', N'池江老街分理处', N'admin', N'2015-09-03 15:13:16', N'admin', N'2015-09-03 15:13:16', 1)
	INSERT INTO [dbo].[Department] ([Code], [Name], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Type]) VALUES (N'13509', N'樟斗支行', N'admin', N'2015-09-03 15:15:15', N'admin', N'2015-09-03 15:15:15', 1)
	INSERT INTO [dbo].[Department] ([Code], [Name], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Type]) VALUES (N'13511', N'青龙支行', N'admin', N'2015-09-03 15:15:42', N'admin', N'2015-09-03 15:15:42', 1)
	INSERT INTO [dbo].[Department] ([Code], [Name], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Type]) VALUES (N'13513', N'黄龙支行', N'admin', N'2015-09-03 15:16:42', N'admin', N'2015-09-03 15:16:42', 1)
	INSERT INTO [dbo].[Department] ([Code], [Name], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Type]) VALUES (N'13514', N'左拔支行', N'admin', N'2015-09-03 15:16:16', N'admin', N'2015-09-03 15:16:16', 1)
	INSERT INTO [dbo].[Department] ([Code], [Name], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Type]) VALUES (N'13515', N'浮江支行', N'admin', N'2015-09-03 15:41:47', N'admin', N'2015-09-03 15:41:47', 1)
	INSERT INTO [dbo].[Department] ([Code], [Name], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Type]) VALUES (N'13517', N'吉村支行', N'admin', N'2015-09-03 15:42:08', N'admin', N'2015-09-03 15:42:08', 1)
	INSERT INTO [dbo].[Department] ([Code], [Name], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Type]) VALUES (N'13518', N'游仙分理处', N'admin', N'2015-09-03 16:13:00', N'admin', N'2015-09-03 16:13:00', 1)
	INSERT INTO [dbo].[Department] ([Code], [Name], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Type]) VALUES (N'13519', N'内良支行', N'admin', N'2015-09-03 16:13:29', N'admin', N'2015-10-03 11:04:53', 1)
	INSERT INTO [dbo].[Department] ([Code], [Name], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Type]) VALUES (N'13520', N'河洞支行', N'admin', N'2015-09-03 16:14:02', N'admin', N'2015-09-03 16:14:02', 1)
	INSERT INTO [dbo].[Department] ([Code], [Name], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Type]) VALUES (N'13522', N'南安支行', N'admin', N'2015-09-03 15:18:07', N'admin', N'2015-09-03 15:18:07', 1)
	INSERT INTO [dbo].[Department] ([Code], [Name], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Type]) VALUES (N'13523', N'西门支行', N'admin', N'2015-09-03 15:18:32', N'admin', N'2015-09-03 15:18:32', 1)
	INSERT INTO [dbo].[Department] ([Code], [Name], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Type]) VALUES (N'13524', N'步行街支行', N'admin', N'2015-09-03 15:18:55', N'admin', N'2015-09-03 15:18:55', 1)
	INSERT INTO [dbo].[Department] ([Code], [Name], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Type]) VALUES (N'13526', N'梅关支行', N'admin', N'2015-09-03 15:41:23', N'admin', N'2015-09-03 15:41:23', 1)
	INSERT INTO [dbo].[Department] ([Code], [Name], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Type]) VALUES (N'13527', N'南门支行', N'admin', N'2015-09-03 15:39:13', N'admin', N'2015-09-03 15:39:13', 1)
	INSERT INTO [dbo].[Department] ([Code], [Name], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Type]) VALUES (N'13529', N'东门支行', N'admin', N'2015-09-03 15:19:32', N'admin', N'2015-09-03 15:19:32', 1)
	INSERT INTO [dbo].[Department] ([Code], [Name], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Type]) VALUES (N'13531', N'营业部', N'admin', N'2015-09-03 16:14:25', N'admin', N'2015-09-03 16:14:25', 1)
	INSERT INTO [dbo].[Department] ([Code], [Name], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Type]) VALUES (N'13532', N'新城街分理处', N'admin', N'2015-08-31 18:18:38', N'admin', N'2015-08-31 18:18:38', 1)
	INSERT INTO [dbo].[Department] ([Code], [Name], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Type]) VALUES (N'13533', N'运管部', N'admin', N'2015-09-03 17:01:33', N'admin', N'2015-09-03 17:01:33', 0)
END


DECLARE @materielNum INT 
SELECT  @materielNum = COUNT(*) FROM [dbo].[Materiel] 
IF(@materielNum = 0)
BEGIN
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'OTHER01', N'传票封面', N'OTHER', N'admin', N'2015-09-30 16:11:28', N'admin', N'2015-09-30 16:11:28')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'OTHER02', N'传票封底', N'OTHER', N'admin', N'2015-09-30 16:12:16', N'admin', N'2015-09-30 16:12:16')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'OTHER03', N'白色扎把带', N'OTHER', N'admin', N'2015-09-30 16:12:42', N'admin', N'2015-09-30 16:12:42')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'OTHER04', N'黄色扎把带', N'OTHER', N'admin', N'2015-09-30 16:13:13', N'admin', N'2015-09-30 16:13:13')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'OTHER05', N'捆钞带', N'OTHER', N'admin', N'2015-09-30 16:20:25', N'admin', N'2015-09-30 16:20:25')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ01', N'贷款本息收回凭证', N'ZKPZ', N'admin', N'2015-09-04 15:43:58', N'admin', N'2015-09-04 15:43:58')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ02', N'单位存单', N'ZKPZ', N'admin', N'2015-09-04 15:44:35', N'admin', N'2015-09-04 15:44:35')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ03', N'定期储蓄一本通（新）', N'ZKPZ', N'admin', N'2015-09-04 15:44:57', N'admin', N'2015-09-04 15:44:57')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ04', N'定期存款证实书', N'ZKPZ', N'admin', N'2015-09-04 15:45:24', N'admin', N'2015-09-04 15:45:24')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ05', N'个人存款证明书', N'ZKPZ', N'admin', N'2015-09-04 15:45:41', N'admin', N'2015-09-04 15:45:41')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ06', N'个人网银证书2', N'ZKPZ', N'admin', N'2015-09-04 15:46:00', N'admin', N'2015-09-04 15:46:00')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ07', N'股金证', N'ZKPZ', N'admin', N'2015-09-04 15:46:20', N'admin', N'2015-09-04 15:46:20')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ08', N'柜员成品卡', N'ZKPZ', N'admin', N'2015-09-04 15:46:42', N'admin', N'2015-09-04 15:46:42')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ09', N'活期存折（新）', N'ZKPZ', N'admin', N'2015-09-04 15:47:00', N'admin', N'2015-09-04 15:47:00')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ10', N'农信银汇票', N'ZKPZ', N'admin', N'2015-09-04 15:49:26', N'admin', N'2015-09-04 15:49:26')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ11', N'企业网银证书A', N'ZKPZ', N'admin', N'2015-09-04 15:49:45', N'admin', N'2015-09-04 15:49:45')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ12', N'手机银行贴片卡', N'ZKPZ', N'admin', N'2015-09-04 15:50:01', N'admin', N'2015-09-04 15:50:01')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ13', N'网银UKEY', N'ZKPZ', N'admin', N'2015-09-04 15:50:23', N'admin', N'2015-09-04 15:50:23')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ14', N'现金支票', N'ZKPZ', N'admin', N'2015-09-04 15:50:53', N'admin', N'2015-09-04 15:50:53')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ15', N'一卡通对账折', N'ZKPZ', N'admin', N'2015-09-04 15:51:27', N'admin', N'2015-09-04 15:51:27')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ16', N'银行本票', N'ZKPZ', N'admin', N'2015-09-04 15:51:46', N'admin', N'2015-09-04 15:51:46')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ17', N'银行承兑汇票', N'ZKPZ', N'admin', N'2015-09-04 15:52:08', N'admin', N'2015-09-04 15:52:08')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ18', N'支付密码器', N'ZKPZ', N'admin', N'2015-09-04 15:52:27', N'admin', N'2015-09-04 15:52:27')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ19', N'转账支票', N'ZKPZ', N'admin', N'2015-09-04 15:52:45', N'admin', N'2015-09-04 15:52:45')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ20', N'资金拆借凭证', N'ZKPZ', N'admin', N'2015-09-04 15:53:02', N'admin', N'2015-09-04 15:53:02')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ21', N'资金拆借凭证收回凭证', N'ZKPZ', N'admin', N'2015-09-04 15:53:24', N'admin', N'2015-09-04 15:53:24')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ22', N'资金调剂凭证', N'ZKPZ', N'admin', N'2015-09-04 15:53:42', N'admin', N'2015-09-04 15:53:42')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'ZKPZ23', N'资金调剂凭证收回凭证', N'ZKPZ', N'admin', N'2015-09-04 15:53:59', N'admin', N'2015-09-04 15:53:59')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'NZKPZ_01', N'个人业务凭证', N'NZKPZ', N'admin', N'2015-10-13 15:40:07', N'admin', N'2015-10-13 15:40:07')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'NZKPZ_02', N'综合小单联', N'NZKPZ', N'admin', N'2015-10-13 15:40:17', N'admin', N'2015-10-13 15:40:17')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'NZKPZ_03', N'综合小双联', N'NZKPZ', N'admin', N'2015-10-13 15:40:27', N'admin', N'2015-10-13 15:40:27')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'NZKPZ_04', N'综合大单联', N'NZKPZ', N'admin', N'2015-10-13 15:40:36', N'admin', N'2015-10-13 15:40:36')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'NZKPZ_05', N'综合大双联', N'NZKPZ', N'admin', N'2015-10-13 15:40:43', N'admin', N'2015-10-13 15:40:43')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'NZKPZ_06', N'现金缴款单', N'NZKPZ', N'admin', N'2015-10-13 15:40:52', N'admin', N'2015-10-13 15:40:52')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'NZKPZ_07', N'进账单', N'NZKPZ', N'admin', N'2015-10-13 15:41:00', N'admin', N'2015-10-13 15:41:00')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'NZKPZ_08', N'个人账户开户申请书', N'NZKPZ', N'admin', N'2015-10-13 15:41:08', N'admin', N'2015-10-13 15:41:08')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'NZKPZ_09', N'挂失申请书', N'NZKPZ', N'admin', N'2015-10-13 15:41:17', N'admin', N'2015-10-13 15:41:17')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'NZKPZ_10', N'结算业务申请书', N'NZKPZ', N'admin', N'2015-10-13 15:41:25', N'admin', N'2015-10-13 15:41:25')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'NZKPZ_11', N'个人业务签约（变更）申请书', N'NZKPZ', N'admin', N'2015-10-13 15:41:33', N'admin', N'2015-10-13 15:41:33')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'DJB_01', N'会计主管工作日志', N'DJB', N'admin', N'2015-10-13 15:53:49', N'admin', N'2015-10-13 15:53:49')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'DJB_02', N'柜员凭证交接登记簿', N'DJB', N'admin', N'2015-10-13 15:53:57', N'admin', N'2015-10-13 15:53:57')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'DJB_03', N'抵质押物品登记簿', N'DJB', N'admin', N'2015-10-13 15:54:05', N'admin', N'2015-10-13 15:54:05')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'JJ_01', N'A类点钞机', N'JJ', N'admin', N'2015-10-13 15:54:19', N'admin', N'2015-10-13 15:54:19')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'JJ_02', N'清分机', N'JJ', N'admin', N'2015-10-13 15:54:27', N'admin', N'2015-10-13 15:54:27')
	INSERT INTO [dbo].[Materiel] ([Code], [Name], [Type], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (N'JJ_03', N'一口半小型清分机', N'JJ', N'admin', N'2015-10-13 15:54:36', N'admin', N'2015-10-13 15:54:36')
END