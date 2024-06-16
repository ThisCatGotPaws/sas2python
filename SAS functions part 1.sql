/*
SAS can handle upto 32,767 vars in a single data set. The no of obs is limited only by the 
computer's capacity.

Rules of SAS names:
Names must be 32 characters or fewer in length
Names must start with a letter or an underscore
Names can contain only letters, numerals or underscore...no special characters
Names can contain upper and lower case letters...SAS is not case sensitive

*/

/****Absolute or Modulus Function*******/
data test;
input a;
cards;
12.34
-145.67
;
data test1;
set test;
x=abs(a);
run;
proc print;
run;

/***Ceil Function*******/ 

/***returns the smallest integer that is greater than or equal to the argument**/
data test;
input a;
cards;
12.34
15.67
;
data test1;
set test;
x=ceil(a);
run;
proc print;
run;
/****Floor Function*******/

/***returns the largest integer that is less than or equal to the argument*****/
data test;
input a;
cards;
12.34
15.67
;
data test1;
set test;
x=floor(a);
run;
proc print;
run;

/****Compress Function*******/

/**Removes specific characters from character expressions****/
data test;
input a $8.;
cards;
AA RT O
AS/ER NB
;
data test1;
set test;
x=compress(a);
y=compress(x,'/');
z=compress(compress(a,'/'));
run;
proc print;
run;

/***Date Function****/

/**Returns the Current date as a SAS Date Value******/
data test;
tday=date();
format tday date9.;
run;
proc print;
run;

/****Datetime Function*******/
data test;
format tday datetime18.;
tday=datetime();
run;
proc print;
run;
/****The Datepart Function*****/

/***returns the date part from the datetime format******/
data test1;
set test;
format x date9.;
x=datepart(dt);
run;
proc print;
run;

/***Day Function*****/

/***returns the day of the month from a SAS date value****/
data test;
informat a date9.;
format a date9.;
input a;
cards;
03Oct2004
15Oct2004
;
data test1;
set test;
x=day(a);
run;
proc print;
run;

/***The DHMS Function*******/

/***Returns a SAS datetime value from the date, hour, minute and second*********/
data test;
format dt datetime18.;
dt=dhms('01Oct2004'd,11,34,12);
run;
proc print;
run;

/***The DIF Function******/

/***Difference with nth lag...default is 1****/
data test;
input a;
cards;
13
45
56
67
87
256
;
data test1;
set test;
x=dif(a);
x1=dif1(a);
x2=dif2(a);
run;
proc print;
run;

/***Exponential Function******/

data test;
x=exp(1);
y=exp(0);
run;
proc print;
run;

/*****The HMS Function**********/

/***returns the SAS time value from hour, minute and second values*****/
data test;
format tt time8.;
tt=hms(11,34,12);
run;
proc print;
run;

/****The Hour Function*******/

/**returns the hour from a SAS time or datetime value*******/
data test1;
set test;
hh=hour(tt);
run;
proc print;
run;


/****The Input function*******/

/***converts character vars to numeric vars********/
data test;
input a $8.;
cards;
125678
342639
563843
655454
;
data test1;
set test;
x=input(a,8.);
z=a*1;
run;
proc print;
run;
proc contents;
run;

/***The INT function********/

/****returns the integer portion of the argument
If the argument's value is positive the result is the same as that of the Floor Function
If the argument's value is negative the result is the same as that of the Ceil Function*******/
data test;
input a;
cards;
12.34
15.67
-12.45
-14.66
;
data test1;
set test;
x=int(a);
run;
proc print;
run;

/****The INTCK Function********/

/****returns the number of intervals in a given time span*******/
data test;
dd=intck('day','01jan1999'd,'31Dec1999'd);
mm=intck('month','01jan1999'd,'31Dec1999'd);
ww=intck('week','01jan1999'd,'31Dec1999'd);
qq=intck('qtr','01jan1999'd,'31Dec1999'd);
yy=intck('year','01jan1999'd,'31Dec1999'd);
run;
proc print;
run;

/****The INTNX Function********/

/***Advances a date, time or datetime value by a given interval******/
data test;
format dd date9.;
dd=intnx('day','31Dec1999'd,-364);
format mm date9.;
mm=intnx('month','31Dec1999'd,-11);
format yy date9.;
yy=intnx('year','31Dec1999'd,0);
run;
proc print;
run;
/* Soundex function*/

data test;
set allegro;
/*data set should contain names, first name , last name*/
/*say you are comparing 2 names Rob & Bob, then take soundex*/
sound1=soundex(ordered_by);
sound2=soundex(ordered_for);
run;




