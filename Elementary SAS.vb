/*
SAS can handle upto 32,767 vars in a single data set. The no of obs is limited only by the 
computer's capacity

Rules of SAS names:
names must be 32 characters or fewer in length
names must start with a letter or an underscore
names can contain only letters, numerals or underscore...no special characters
names can contain upper and lower case letters...SAS is not case sensitive

*/

/****Creating  data sets in SAS*****/

/**Creating a data set with a single obs***/
data test;
x=2; y=3;
run;
proc print;
run;

/****Creating a data set with multiple obs*******/
data test;
input a b;
cards;
12 34
37 45
32 88
;
proc print;
run;

/***Creating a data set with a character var****/
data test;
input a $ b $6.;
cards;
12 Jack
37 James
;
proc print;
run;

/***Equivalent statement for cards is datalines*****/
data test;
input a b;
datalines;
12 34
37 45
32 88
;
proc print;
run;

/****Creating a data set with length specifications***/
data t;
input city $ 1-10 Street $ 11-21 Revenue 22-25 Cost 26-28;
cards;
BANGALORE Church st  234 23
CHENNAI	  T NAGAR    657 67
DELHI     CP         564 34
KANPUR    MG ROAD    455 36
;
run;
proc print;
run;

/****making an exact copy of a data set*****/
data test1;
set sashelp.class;
run;
proc print data = test1;
run;

/******creating a new var using a label stmt*******/
data test1;
set test;
y=2+b-a;
label y='New Var';
run;
proc print data=test1 ;
run;

/*to see the label in the print output use the label stmt***/
proc print data=test1 label;
run;

/***writing a var with a $ infront or by using commas**/
data test1;
set test;
z=1000*a;
z1=1000*b; 
format z dollar20.;
format z1 comma20.;
run;
proc print;
run;
 
/****dropping or keeping vars*********/
data test1;
set test(keep=a);
run;
proc print;
run;
data test1;
set test(drop=a);
run;
proc print;
run;

/****Renaming Vars***********/
data test1(rename=(a=x b=y));
set test;
run;
proc print;
run;

/**Alternative ways of writing the drop, keep and rename statements****/
data test;
input a b c d;
cards;
1 2 3 4
2 4 6 9
;
data test1;
set test;
drop b;
keep a d;
rename a=s;
run;
proc print;
run;

/****Concatenating Variables*********/
data test1;
set test;
x=compress(a||b);
run;
proc print;
run;

/***Subsetting based on values of obs******/
data test;
input a b;
datalines;
12 34
37 45
32 88
;
proc print;
run;
data test1;
set test;
where a<=32;
run;
proc print	;
run;

/***Creating two data sets****/
data test1 test2;
set test;
if a=12 then output test1;else output test2;
run;
proc print data = test1 ;
run;
proc print data = test2 ;
run;

/***Subsetting using delete*****/
data test1;
set test;
if a = 12 then delete;
run;
proc print;
run;

/*Note: Delete does not work with the Where condition. It only works with the If Condition**/

/**Creating a permanent data set********/
libname in 'd:\';
data in.test;
set test;
run;
proc print data = in.test;
run;
 
/***Format and Informat****/

/*Format does not alter the value when stored. It is used only for reading output*******/

data temp;
informat a date9.;
format a mmddyy10.;
input a;
cards;
23Jun2001
23Jul2002
;
proc print;
run;
proc contents ;
run;


/***IF-THEN & DO/END statements*******/

data test1;
set test;
if a=12 then cat=100;else cat=44;
run;
proc print;
run;

data test1;
set test;
if a=12 then do;
cat=1;cat1=5;
end;
else do;
cat=0;cat1=10;
end;
run ;
proc print;
run;

/********Min-Max Statements********/
data test;
input a b;
datalines;
12 34
37 45
32 88
;
proc print;
run;
data test1;
set test;
c=max(a,b);
d=min(a,b);
e=min(max(b,40),50);
run;
proc print;
run;

/****Using the sum function****/
data test1;
set test;
c=sum(a,b);
run;
proc print;
run;

/****Combining Two Data  Sets*********/

/*******Using the Set statement***********/
data t1;
input a b;
cards;
1 44
2 34
3 56
;
data t2;
input a b;
cards;
4 23
5 12
6 78
;
data tt;
set t1 t2;
run;
proc print;
run;

/***Merging*****/
data t1;
input a b;
cards;
1 44
2 34
3 56
;
data t2;
input a c;
cards;
2 23
3 12
6 78
;
proc sort data = t1;by a;run;
proc sort data = t2;by a;run;  
data tt;
merge t1(in=aa) t2(in=bb);
by a;
run;
proc print;
run;

data tt;
merge t1(in=aa) t2(in=bb);
by a;
if aa or bb;
run;
proc print;
run;

data tt;
merge t1(in=aa) t2(in=bb);
by a;
if aa and bb;
run;
proc print;
run;

data tt;
merge t1(in=aa) t2(in=bb);
by a;
if aa ;
run;
proc print;
run;

data tt;
merge t1(in=aa) t2(in=bb);
by a;
if bb ;
run;
proc print;
run;

data tt;
merge t1(in=aa) t2(in=bb);
by a;
if aa and not bb;
run;
proc print;
run;

data tt;
merge t1(in=aa) t2(in=bb);
by a;
if not aa and bb;
run;
proc print;
run;

/***BY Process and use of First. and Last. Statements******/
data test;
informat b date9.; 
format b date9.;
input a b;
cards;
1 23jun1998
3 02dec2003
1 08may2002
2 25oct2003
1 12jan2000
3 10may2002
1 11apr2001
;
proc sort data = test;by a b;run;
data test1;
set test;
by a;
if first.a;
run;
proc print;
run;
data test1;
set test;
by a;
if last.a;
run;
proc print;
run;
data test1;
set test;
by a;
if first.a and last.a;
run;
proc print;
run;
data test1;
set test;
by a;
if first.a and last.a then delete;
run;
proc print;
run;

/******Cumulating using the By Process******/

/***Use of Retain statement****/
data test1;
set test;
by a;
retain x;
if first.a then x=1;else x=sum(x,1);
run;
proc print;
run;

/***Alternative way of cumulating without using the Retain statement***/
data test1;
set test;
by a;
if first.a then x=1;else x+1;
run;
proc print;
run;

/***Using data _null_ and put statement***/
data _null_;
x=5;
y=x**2;
put x y;
run;

/*data sherine;*/
/*x=5;*/
/*y=x**2;*/
/*put x y;*/
/*run;*/

/**we cannot give the name _null_ to any dataset. This is reserved for SAS.This will not create a data set. This 
will only put the output in the Log***/

/***Using the var _n_ ****/

/**_n_ is a var that is internal to the data set which says which obs it is***/
data t1;
input a b;
cards;
6 44
4 34
1 56
;
data test1;
set t1;
if _n_<=2;
run;
proc print data = test1;
run;

/***concept of Remote Processing******/

/*filename rlink 'c:\contact.txt';*/
/*         %let rahul= 3.171.120.17;*/
/*		 options comamid=tcp remote=rahul;*/
/*		 signon;*/
/**/
/*rsubmit;*/
/*libname in '/gmt/stg2/dataloads/in/countrywide/mar05/cd1';*/
/**rsubmit;*/
/*proc datasets lib=in;*/
/*quit;*/
/**rsubmit;*/
/*proc contents data=in.loans;*/
/*run;*/
/**signoff;*/

/****Some other operators********/

/***Select Statement*********/
data test;
input x $3. y;
cards;
ab 12
acb 13
ac 14
d  15
;
data test1;
set test;
select (y);
when (12,13) x1=1;
when (15) x1=2;
otherwise x1=0;
end;
run;
proc print;
run; 

/*******Contains Statement***********/
data test1;
set test;
where x contains ('a');
run;

proc print ;
run;

/******Like Statement**********/
data test1;
set test;
where x like ('%b');
run;
proc print ;
run;
