# -*- coding: utf-8 -*-
"""
Orbital Mechanics Quick Calcs

Created on Sat Oct 19 00:35:43 2019

@author: iohaz
"""

from pylab import *

r_earth = 6371e3 # [m] Earth Radius

mu = 3.98e14 # Earth
#mu = 4.9e12  # Moon

#42000 km GEO
#27000 km GPS
#6746 km ISS
r  = 6746e3 # Orbital Radius
v = sqrt(mu/r)

dvdr = -0.5*sqrt(mu/r**3)
drdv = -2*mu/v**3

print("Orbital Radius = %0.3f km" % (r/1e3))
print("mu             = %0.2e" % (mu))
print("dv/dr          = %0.3f" % (dvdr))
print("dr/dv          = %0.3f" % (drdv))

figure(1)
clf()
ors = linspace(6e6,42e6,1000)
plot(ors/1e3, -0.5*sqrt(mu/ors**3)*1e3)
grid(True)

#dr = 10.0
#dv = 100.0
#
#mu = dv**2/(-2/(sqrt(r)+sqrt(r*dr))+1/(r+dr)+1/r)
#
#print("Given a radius of %0.1f km and a delta of %0.1f m/s per %0.1f m" % (r/1e3, dv, dr))
#print("mu = %0.2e" % mu)
#
#
#dva = sqrt(mu/(r+dr)) - sqrt(mu/r)
#
#print("Given a radius of %0.1f km and a mu of %0.2e" % (r/1e3, mu))
#print("A delta of %0.3f m/s per %0.1f m" % (dva, dr))


