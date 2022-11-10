//Danh sach lien ket don
#include <stdio.h>
#include<iostream>
#include<string>
using namespace std;

// tao kieu thong tin cho san pham
struct infoProduct {
	string nameProduct;
	int amount;
};
typedef struct infoProduct iP;

// tao kieu thong tin cho Node
struct Node {
	iP data;
	Node* next;
	void setNext(Node* tmp) {
		this->next = tmp;

	}
	Node() {
		data.amount = 0;
		data.nameProduct = "";
	}
	Node* getNext() {
		return next;
	}
};

typedef struct Node* node;

// Tao kieu thong tin cho List de luu cac Node
struct List {
	node pHead;
	node pTail;
};

// Khoi tao 1 List moi
void newList(List& ds) {
	ds.pHead = NULL;
	ds.pHead = NULL;
}
// Kiem tra 1 List co rong khong
int checkEmptyList(List ds) {
	if (ds.pHead == NULL) {
		return 1;
	}
	return 0;
}
//Cap phat dong mot node moi 
node makeNode(iP x) {
	node tmp = new Node;
	if (tmp == NULL) {
		printf("KHONG DU BO NHO");
		return NULL;
	}
	tmp->data = x;
	tmp->next = NULL; //nullptr
	return tmp;
}

//Kiem tra rong
// int KiemTraRong(LIST ds){
int KiemTraRong(List ds) {
	if (ds.pHead == NULL) {
		return 1;
	}
	return 0;
}
// chen cuoi
void insertLast(List& ds, node p) {
	if (ds.pHead == NULL) {
		ds.pHead = p;
		ds.pTail = p;
	}
	else {
		ds.pTail->next = p;
		ds.pTail = p;
	}
}

node find(List ds, string x) {
	//tao node p
	node p=new Node;
	//gan p bang phan tu dau danh sach
	p = ds.pHead;
	//su dung vong lap
	while ((p != NULL) && (p->data.nameProduct != x)) {
		p = p->next;
	}
	//tra ve ket qua, neu NULL thi khong tim thay
	return p;
}

void deleteFirst(List& ds) {
	//tao node p
	node p = new Node;
	//gan p bang node pHead dau tien cua danh sach 
	p = ds.pHead;
	
	ds.pHead = ds.pHead->next;
	
	p->next = NULL;
	//xoa node p
	delete p;
}
void deleteLast(List& ds)
{
	//duyet cac phan tu co trong danh sach
	for (node k = ds.pHead; k != NULL; k = k->next)
	{
		//neu duyet den phan tu pTail cuoi trong danh sach
		if (k->next == ds.pTail)
		{
			//xoa phan tu cuoi
			delete ds.pTail;
			//tro phan tu truoc phan tu cuoi ve NULL
			k->next = NULL;
			//thay doi lai phan tu cuoi pTail cua danh sach
			ds.pTail = k;
		}
	}
}
void deleteByFind(List& ds, string &x) {
	node p = new Node;
	node k= new Node;
	//neu data dau vao bang voi pHead->data thi xoa dau
	if (ds.pHead->data.nameProduct == x) {
		//goi ham xoa dau
		deleteFirst(ds);
		//ket thuc ham
		return;
	}
	//neu data bang voi pTail->data thi xoa cuoi
	if (ds.pTail->data.nameProduct == x) {
		//goi ham xoa cuoi
		deleteLast(ds);
		//ket thuc ham
		return;
	}
	//duyet qua cac phan tu co trong danh sach
	for (node k = ds.pHead; k != NULL; k = k->next) {
		//neu tim thay data trung voi k->data dang duyet
		if (k->data.nameProduct == x) {
			//gan con tro next cua node p bang con tro next cua node k
			p->next = k->next;
			//xoa di node k
			delete k;
			//ket thuc ham
			return;
		}
		//gan node p bang node k de node p luon la node dung truoc node k
		p = k;
	}
}
//xoa cac phan tu trung nhau trong list
void delDup(List& l) {
	node p1;
	node p2;
	node dup;
    
	p1 = l.pHead;
	if (p1 == NULL) {
		return;
	}
	

	while (p1->getNext() != NULL) {
		p2 = p1;
		while (p2->getNext() != NULL) {
			if (p1->data.nameProduct == (p2->getNext()->data.nameProduct)) {
				dup = p2->getNext();
				p2->setNext( p2->getNext()->getNext());
				delete(dup);
			}
			else {
				p2 = p2->getNext();
			}

		}
		p1 = p1->getNext();
		}
	return;
}

void Input(List& ds) {
	    printf("NHAP THONG TIN SAN PHAM \n");
		cin.ignore(32767, '\n');
		iP x; 
		node p = new Node;
		cout << "Nhap ten san pham:= ";
		getline(cin, x.nameProduct);
		cout << "Nhap so luong san pham:= ";
		cin >> x.amount;
		int count = 0;
		
		
		node tmp = new Node;
		tmp = makeNode(x);
		insertLast(ds, tmp);
}
void checkKho(List& ds) {
	node p = new Node;
	for (node p = ds.pHead; p != NULL; p = p->next) {
		
	}
}
void test(List& ds) {
	node p = new Node;
	p = ds.pHead;
	if (p == NULL) {
		cout << "NUll";
		return;
	};
	cout << p->data.amount;
	cout << p->data.nameProduct;
}

void Output(List ds) {
	for (node p = ds.pHead; p != NULL; p = p->next) {
		cout << "(" << p->data.nameProduct << "," << p->data.amount << ")" << endl;

	}
}


int main() {
	/*List ds;
	int n;
	cout << "Nhap so lan muon nhap:= ";
	cin >> n;

	newList(ds);
	Input(ds, n);
	cout << "DANH SACH SAN PHAM" << endl;;
	Output(ds);*/
	List oder; newList(oder);
	List notSale; newList(notSale);
	List sale; newList(sale);
	List product; newList(product);
	while (1) {
		cout << "-----------------MENU---------------\n";
		cout << "1. Them san pham oder vao hang doi o cuoi danh sach\n";
		cout << "2. Them san pham vao kho o cuoi danh sach\n";

		cout << "3.  Duyet danh sach oder\n";
		cout << "4.  Duyet danh sach chua ban duoc\n";
		cout << "5.  Duyet danh sach da ban duoc\n";
		cout << "6.  Duyet danh sach san pham\n";
		cout << "7.  xoa cac muc trung theo dieu kien\n";
		cout << "8.  xoa tat ca cac muc trung\n";
		cout << "9. tesst\n";
		cout << "0. Thoat !\n";
		cout << "-------------------------------------\n";
		cout << "Nhap lua chon :";
		int lc; cin >> lc;
		if (lc == 1) {
			
			Input(oder);
		}
		else if (lc == 2) {
			
			
			
			Input(product);
		}
		else if (lc == 3) {
			cout << "DANH SACH SAN PHAM oder" << endl;;
			Output(oder); 
		}
		else if (lc == 4) {
			cout << "DANH SACH SAN PHAM chua ban duoc" << endl;;
			Output(oder);
		}
		else if (lc == 5) {
			cout << "DANH SACH SAN PHAM da ban duoc" << endl;;
			Output(oder);
		}
		else if (lc == 6) {
			cout << "DANH SACH tat ca SAN PHAM da co trong kho " << endl;;
			Output(oder);
		}
		else if (lc == 7) {
			//cout << "Xoa cac hang trung " << endl;;
		//	deleteByFind(oder, "c");
		}
		else if (lc == 8) {
			cout << "Xoa tat ca cac muc trung " << endl;;
			delDup(oder);
		}
		else if (lc == 9) {
			cout << "test " << endl;;
			test(oder);

		}
		else if (lc == 0) {
			break;
		}
	}
	return 0;

}


