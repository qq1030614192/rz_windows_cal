#include "stdafx.h"
#include "mydll.h"

double _stdcall add(double a, double b) {
	return(a + b);
}
double _stdcall subtract(double a, double b) {
	return(a - b);
}
double _stdcall multiply(double a, double b) {
	return(a * b);
}
double _stdcall divide(double a, double b) {
	return(a / b);
}