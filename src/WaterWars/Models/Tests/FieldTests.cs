/*
 * Copyright (2011) Intel Corporation and Sandia Corporation. Under the
 * terms of Contract DE-AC04-94AL85000 with Sandia Corporation, the
 * U.S. Government retains certain rights in this software.
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 
 * -- Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 * -- Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in the
 *    documentation and/or other materials provided with the distribution.
 * -- Neither the name of the Intel Corporation nor the names of its
 *    contributors may be used to endorse or promote products derived from
 *    this software without specific prior written permission.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 * ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
 * LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
 * PARTICULAR PURPOSE ARE DISCLAIMED.  IN NO EVENT SHALL THE INTEL OR ITS
 * CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
 * EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
 * PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
 * PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
 * LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *
 */

using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using OpenMetaverse;
using OpenSim.Tests.Common;
using WaterWars.Models;

namespace WaterWars.Models.Tests
{ 
    [TestFixture]
    public class FieldTests
    {
        [Test]
        public void TestBuyPoint()
        {
            TestHelper.InMethod();            
                        
            // The field class has already constructed Field.None, which conceptually belongs to BuyPoint.None
            Assert.That(BuyPoint.None.Fields.Count, Is.EqualTo(1));
              
            Field f1 = new Field(UUID.Parse("00000000-0000-0000-0001-000000000000"), "f1");
            
            // Both f1 and Field.None are attached to BuyPoint.None at this point
            Assert.That(BuyPoint.None.Fields.Count, Is.EqualTo(2));
            Assert.That(f1.BuyPoint, Is.EqualTo(BuyPoint.None));

            BuyPoint bp1 = new BuyPoint(UUID.Parse("00000000-0000-0000-0000-000000000010"));
            Assert.That(bp1.Fields.Count, Is.EqualTo(0));
            Assert.That(BuyPoint.None.Fields.Count, Is.EqualTo(2));

            f1.BuyPoint = bp1;

            Assert.That(BuyPoint.None.Fields.Count, Is.EqualTo(1));
            Assert.That(bp1.Fields.Count, Is.EqualTo(1));
            Assert.That(f1.BuyPoint, Is.EqualTo(bp1));            
        }
    }
}