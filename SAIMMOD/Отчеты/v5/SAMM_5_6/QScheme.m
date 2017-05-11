function [numchan,profit]=QScheme(inpint,proctime,chansum,oneprof,tm)
%Models effectivity of Erlang M/M/n Q-scheme.
for i=1:1:20
  A(i) = ((inpint*sqrt(proctime))^i)/factorial(i);
  B(i) = oneprof*inpint*(1-A(i)*(1/(1+sum(A(1:i)))))-chansum*i;
end;
B,
plot(B);
[C,num] = max(B);
numchan=num;
profit=C*tm;