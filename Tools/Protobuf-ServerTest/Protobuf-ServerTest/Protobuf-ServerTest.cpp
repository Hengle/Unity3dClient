// Protobuf-ServerTest.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include <WinSock2.h>
#include <windows.h>
#include <string>
using namespace std;
#define  PORT 8880  
#include "LogItem.pb.h"

bool InitNetEnv()
{
	// 进行网络环境的初始化操作  
	WSADATA wsa;
	if (WSAStartup(MAKEWORD(2, 2), &wsa) != 0)
	{
		printf("WSAStartup failed\n");
		return false;
	}
	return true;
}

string UTF8_2_GBK(string utf8Str);
string GBK_2_UTF8(string gbkStr);
string GetLogTypeString(int logType);

DWORD WINAPI clientProc(
	LPVOID lparam
	)
{
	SOCKET sockClient = (SOCKET)lparam;
	char buf[1024];
	while (TRUE)
	{
		memset(buf, 0, sizeof(buf));
		// 接收客户端的一条数据   
		int ret = recv(sockClient, buf, sizeof(buf), 0);
		//检查是否接收失败  
		if (SOCKET_ERROR == ret)
		{
			printf("socket recv failed\n");
			closesocket(sockClient);
			return -1;
		}
		// 0 代表客户端主动断开连接  
		if (ret == 0)
		{
			printf("client close connection\n");
			closesocket(sockClient);
			return -1;
		}

		Protocol::LogItem _LogItem;
		if (_LogItem.ParseFromArray(buf, ret))
		{
			printf("[id = %06d][%s]\n", _LogItem.logid(), GetLogTypeString((int)_LogItem.elogtype()).c_str());
			printf("name = %s\n\n", UTF8_2_GBK(_LogItem.logvalue()).c_str());
		}
		else
		{
			printf("parse error!");
		}
		/*
		// 发送数据  
		ret = send(sockClient, buf, strlen(buf), 0);
		//检查是否发送失败  
		if (SOCKET_ERROR == ret)
		{
			printf("socket send failed\n");
			closesocket(sockClient);
			return -1;
		}
		*/
	}
	closesocket(sockClient);
	return 0;
}

string GetLogTypeString(int logType)
{
	switch (logType)
	{
	case  ((int)Protocol::LogItem_LogType_LT_NORMAL):
	{
		return "Normal";
	}
	break;
	case  ((int)Protocol::LogItem_LogType_LT_WARNING):
	{
		return "Warning";
	}
	break;
	case  ((int)Protocol::LogItem_LogType_LT_ERROR):
	{
		return "Error";
	}
	break;
	case  ((int)Protocol::LogItem_LogType_LT_PROCESS):
	{
		return "Process";
	}
	break;
	default:
		break;
	}
	return "Normal";
}

//需要包含windows.h等头文件

string GBK_2_UTF8(string gbkStr)
{
	string outUtf8 = "";
	int n = MultiByteToWideChar(CP_ACP, 0, gbkStr.c_str(), -1, NULL, 0);
	WCHAR *str1 = new WCHAR[n];
	MultiByteToWideChar(CP_ACP, 0, gbkStr.c_str(), -1, str1, n);
	n = WideCharToMultiByte(CP_UTF8, 0, str1, -1, NULL, 0, NULL, NULL);
	char *str2 = new char[n];
	WideCharToMultiByte(CP_UTF8, 0, str1, -1, str2, n, NULL, NULL);
	outUtf8 = str2;
	delete[]str1;
	str1 = NULL;
	delete[]str2;
	str2 = NULL;
	return outUtf8;
}


string UTF8_2_GBK(string utf8Str)
{
	string outGBK = "";
	int n = MultiByteToWideChar(CP_UTF8, 0, utf8Str.c_str(), -1, NULL, 0);
	WCHAR *str1 = new WCHAR[n];
	MultiByteToWideChar(CP_UTF8, 0, utf8Str.c_str(), -1, str1, n);
	n = WideCharToMultiByte(CP_ACP, 0, str1, -1, NULL, 0, NULL, NULL);
	char *str2 = new char[n];
	WideCharToMultiByte(CP_ACP, 0, str1, -1, str2, n, NULL, NULL);
	outGBK = str2;
	delete[] str1;
	str1 = NULL;
	delete[] str2;
	str2 = NULL;
	return outGBK;
}

int main()
{
	if (!InitNetEnv())
	{
		return -1;
	}

	// 初始化完成，创建一个TCP的socket  
	SOCKET sServer = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	//检查是否创建失败  
	if (sServer == INVALID_SOCKET)
	{
		printf("socket failed\n");
		return -1;
	}
	printf("Create socket OK\n");
	//进行绑定操作  
	SOCKADDR_IN addrServ;
	addrServ.sin_family = AF_INET; // 协议簇为IPV4的  
	addrServ.sin_port = htons(PORT); // 端口  因为本机是小端模式，网络是大端模式，调用htons把本机字节序转为网络字节序  
	addrServ.sin_addr.S_un.S_addr = INADDR_ANY; // ip地址，INADDR_ANY表示绑定电脑上所有网卡IP  
												//完成绑定操作  
	int ret = bind(sServer, (sockaddr *)&addrServ, sizeof(sockaddr));
	//检查绑定是否成功  
	if (SOCKET_ERROR == ret)
	{
		printf("socket bind failed\n");
		WSACleanup(); // 释放网络环境  
		closesocket(sServer); // 关闭网络连接  
		return -1;
	}
	printf("socket bind OK\n");
	// 绑定成功，进行监听  
	ret = listen(sServer, 10);
	//检查是否监听成功  
	if (SOCKET_ERROR == ret)
	{
		printf("socket listen failed\n");
		WSACleanup();
		closesocket(sServer);
		return -1;
	}
	printf("socket listen OK\n");
	// 监听成功  
	sockaddr_in addrClient; // 用于保存客户端的网络节点的信息  
	int addrClientLen = sizeof(sockaddr_in);
	while (TRUE)
	{
		//新建一个socket，用于客户端  
		SOCKET *sClient = new SOCKET;
		//等待客户端的连接  
		*sClient = accept(sServer, (sockaddr*)&addrClient, &addrClientLen);
		if (INVALID_SOCKET == *sClient)
		{
			printf("socket accept failed\n");
			WSACleanup();
			closesocket(sServer);
			delete sClient;
			return -1;
		}
		//创建线程为客户端做数据收发  
		CreateThread(0, 0, (LPTHREAD_START_ROUTINE)clientProc, (LPVOID)*sClient, 0, 0);
	}
	closesocket(sServer);
	WSACleanup();
	return 0;
}