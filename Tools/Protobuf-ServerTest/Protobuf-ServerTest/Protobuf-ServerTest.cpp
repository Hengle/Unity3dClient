// Protobuf-ServerTest.cpp : �������̨Ӧ�ó������ڵ㡣
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
	// �������绷���ĳ�ʼ������  
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
		// ���տͻ��˵�һ������   
		int ret = recv(sockClient, buf, sizeof(buf), 0);
		//����Ƿ����ʧ��  
		if (SOCKET_ERROR == ret)
		{
			printf("socket recv failed\n");
			closesocket(sockClient);
			return -1;
		}
		// 0 ����ͻ��������Ͽ�����  
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
		// ��������  
		ret = send(sockClient, buf, strlen(buf), 0);
		//����Ƿ���ʧ��  
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

//��Ҫ����windows.h��ͷ�ļ�

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

	// ��ʼ����ɣ�����һ��TCP��socket  
	SOCKET sServer = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	//����Ƿ񴴽�ʧ��  
	if (sServer == INVALID_SOCKET)
	{
		printf("socket failed\n");
		return -1;
	}
	printf("Create socket OK\n");
	//���а󶨲���  
	SOCKADDR_IN addrServ;
	addrServ.sin_family = AF_INET; // Э���ΪIPV4��  
	addrServ.sin_port = htons(PORT); // �˿�  ��Ϊ������С��ģʽ�������Ǵ��ģʽ������htons�ѱ����ֽ���תΪ�����ֽ���  
	addrServ.sin_addr.S_un.S_addr = INADDR_ANY; // ip��ַ��INADDR_ANY��ʾ�󶨵�������������IP  
												//��ɰ󶨲���  
	int ret = bind(sServer, (sockaddr *)&addrServ, sizeof(sockaddr));
	//�����Ƿ�ɹ�  
	if (SOCKET_ERROR == ret)
	{
		printf("socket bind failed\n");
		WSACleanup(); // �ͷ����绷��  
		closesocket(sServer); // �ر���������  
		return -1;
	}
	printf("socket bind OK\n");
	// �󶨳ɹ������м���  
	ret = listen(sServer, 10);
	//����Ƿ�����ɹ�  
	if (SOCKET_ERROR == ret)
	{
		printf("socket listen failed\n");
		WSACleanup();
		closesocket(sServer);
		return -1;
	}
	printf("socket listen OK\n");
	// �����ɹ�  
	sockaddr_in addrClient; // ���ڱ���ͻ��˵�����ڵ����Ϣ  
	int addrClientLen = sizeof(sockaddr_in);
	while (TRUE)
	{
		//�½�һ��socket�����ڿͻ���  
		SOCKET *sClient = new SOCKET;
		//�ȴ��ͻ��˵�����  
		*sClient = accept(sServer, (sockaddr*)&addrClient, &addrClientLen);
		if (INVALID_SOCKET == *sClient)
		{
			printf("socket accept failed\n");
			WSACleanup();
			closesocket(sServer);
			delete sClient;
			return -1;
		}
		//�����߳�Ϊ�ͻ����������շ�  
		CreateThread(0, 0, (LPTHREAD_START_ROUTINE)clientProc, (LPVOID)*sClient, 0, 0);
	}
	closesocket(sServer);
	WSACleanup();
	return 0;
}