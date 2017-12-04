Module Query
    Public Sub CheckCat(ByVal category As String)
        RS = CN.Execute("SELECT * FROM category WHERE cat_name = '" & category & "'")
    End Sub

    Public Sub AddCat(ByVal category As String)
        CN.Execute("INSERT INTO category SET cat_name = '" & category & "'")
    End Sub

    Public Sub SelectCat()
        RS = CN.Execute("SELECT cat_name FROM category ORDER BY cat_name")
    End Sub

    Public Sub SelectEmp()
        RS = CN.Execute("SELECT * FROM employees, emppos WHERE employees.emp_PosID = emppos.PosID ORDER BY employees.emp_Lname")
    End Sub

    Public Sub getPosID(ByVal pos As String)
        RS = CN.Execute("SELECT PosID FROM emppos WHERE PosName = '" & pos & "'")
    End Sub

    Public Sub SelectProd()
        RS = CN.Execute("SELECT * FROM products ORDER BY prod_name")
    End Sub

    Public Sub AddProduct(ByVal PN As String, ByVal PC As String, ByVal PCat As Integer, ByVal PP As Double)
        CN.Execute("INSERT INTO products SET prod_name = '" & PN & "', prod_code = '" & PC & "', prod_cat = '" & PCat & "', prod_price = '" & PP & "', prod_stock = '0'")
    End Sub

    Public Sub GetCatID(ByVal cat As String)
        RS = CN.Execute("SELECT cat_ID FROM category WHERE cat_name = '" & cat & "' LIMIT 1")
    End Sub

    Public Sub GetProductInfo(ByVal id As Integer)
        RS = CN.Execute("SELECT * FROM products WHERE PID = '" & id & "' LIMIT 1")
    End Sub

    Public Sub GetCatName(ByVal id As Integer)
        RS = CN.Execute("SELECT cat_name FROM category WHERE cat_ID = '" & id & "' LIMIT 1")
    End Sub

    Public Sub UpdateProd(ByVal prodID As Integer, ByVal PN As String, ByVal PC As String, ByVal PCat As Integer, ByVal PP As Double)
        CN.Execute("UPDATE products SET prod_name = '" & PN & "', prod_code = '" & PC & "', prod_cat = '" & PCat & "', prod_price = '" & PP & "' WHERE PID = '" & prodID & "' ")
    End Sub

    Public Sub AddStock(ByVal id As Integer, ByVal stock As Integer)
        CN.Execute("UPDATE products SET prod_stock = '" & stock & "' WHERE PID = '" & id & "'")
    End Sub

    Public Sub SearchCat(ByVal cat As String)
        RS = CN.Execute("SELECT * FROM products, category WHERE category.cat_ID = products.prod_cat AND category.cat_name = '" & cat & "' ORDER BY prod_name")
    End Sub

    Public Sub SelectProdByInput(ByVal name As String)
        RS = CN.Execute("SELECT * FROM products WHERE prod_name LIKE '%" & name & "%' OR prod_code LIKE '%" & name & "%' ORDER BY prod_name")
    End Sub

    Public Sub checkCode(ByVal code As String)
        RS = CN.Execute("SELECT * FROM products WHERE prod_code = '" & code & "'")
    End Sub

    Public Sub checkCode2(ByVal code As String, ByVal id As Integer)
        RS = CN.Execute("SELECT * FROM products WHERE prod_code = '" & code & "' AND PID != '" & id & "'")
    End Sub

    Public Sub saveEmp(ByVal id As String, ByVal fn As String, ByVal ln As String, ByVal mn As String, ByVal add As String, ByVal dob As String, ByVal dh As String, ByVal pos As String, ByVal user As String, ByVal pass As String, ByVal pic As String, ByVal gender As String)
        CN.Execute("INSERT INTO employees SET emp_id = '" & id & "', emp_Fname = '" & fn & "', emp_Lname = '" & ln & "', emp_Mname = '" & mn & "', emp_Bdate = '" & dob & "', emp_DateHire = '" & dh & "', emp_Address = '" & add & "', emp_PosID = '" & pos & "', emp_pic = '" & pic & "', emp_Gender = '" & gender & "'")
        CN.Execute("INSERT INTO account SET emp_ID = '" & id & "', emp_uName = AES_ENCRYPT('" & user & "', 'key'), emp_Pass = AES_ENCRYPT('" & pass & "', 'key')")
    End Sub

    Public Sub getPosition()
        RS = CN.Execute("SELECT * FROM emppos ORDER BY PosName")
    End Sub

    Public Sub getSpecificPosition(ByVal id As String)
        RS = CN.Execute("SELECT * FROM emppos WHERE PosID = '" & id & "'")
    End Sub

    Public Sub checkPic(ByVal id As String)
        RS = CN.Execute("SELECT emp_pic FROM employees WHERE emp_id = '" & id & "'")
    End Sub

    Public Sub getAllEmp(ByVal id As String)
        RS = CN.Execute("SELECT * FROM employees WHERE emp_id = '" & id & "'")
    End Sub

    Public Sub getAllEmp2(ByVal id As String)
        RS = CN.Execute("SELECT AES_DECRYPT(emp_Uname, 'key') FROM account WHERE emp_ID = '" & id & "'")
    End Sub

    Public Sub UpdateEmp(ByVal id As String, ByVal fn As String, ByVal ln As String, ByVal mn As String, ByVal add As String, ByVal dob As String, ByVal gender As String, ByVal pic As String)
        CN.Execute("UPDATE employees SET emp_Fname = '" & fn & "', emp_Lname = '" & ln & "', emp_Mname = '" & mn & "', emp_Address = '" & add & "', emp_Bdate = '" & dob & "', emp_Gender = '" & gender & "', emp_pic = '" & pic & "' WHERE emp_id = '" & id & "'")
    End Sub

    Public Sub CheckInfo(ByVal uname As String, ByVal pass As String)
        RS = CN.Execute("SELECT emp_ID FROM account WHERE emp_Uname = AES_ENCRYPT('" & uname & "','key') AND emp_Pass = AES_ENCRYPT('" & pass & "','key')")
    End Sub

    Public Sub getEmpByInput(ByVal input As String)
        RS = CN.Execute("SELECT * FROM employees WHERE emp_Fname LIKE '%" & input & "%' OR emp_Lname LIKE '%" & input & "%' OR emp_id LIKE '%" & input & "%' ORDER BY emp_Lname")
    End Sub

    Public Sub SearchPos(ByVal cat As String)
        RS = CN.Execute("SELECT * FROM employees, emppos WHERE employees.emp_PosID = emppos.PosID AND emppos.PosName = '" & cat & "' ORDER BY employees.emp_Lname")
    End Sub

    Public Sub checkStock(ByVal id As Integer)
        RS = CN.Execute("SELECT prod_stock FROM products WHERE PID = '" & id & "'")
    End Sub

    Public Sub buyProducts(ByVal id As Integer, ByVal stock As Integer, ByVal item As Integer)
        CN.Execute("UPDATE products SET prod_stock = '" & stock & "' WHERE PID = '" & id & "'")
        RS = CN.Execute("SELECT * FROM  delivery WHERE pid = '" & id & "' ORDER BY exp_date")
        If Not RS.EOF Then
            Dim r As Integer = item
            Do Until RS.EOF
                If RS.Fields("stock").Value <= r Then
                    CN.Execute("UPDATE delivery SET stock = '0' WHERE pid = '" & RS.Fields("pid").Value & "' AND exp_date = '" & RS.Fields("exp_date").Value & "'")
                    r = r - RS.Fields("stock").Value
                ElseIf RS.Fields("stock").Value > r Then
                    CN.Execute("UPDATE delivery SET stock = '" & RS.Fields("stock").Value - r & "' WHERE pid = '" & RS.Fields("pid").Value & "' AND exp_date = '" & RS.Fields("exp_date").Value & "'")
                    Exit Do
                End If
                RS.MoveNext()
            Loop
        End If
    End Sub

    Public Sub getDeliveries(ByVal id As String)
        RS = CN.Execute("SELECT * FROM delivery, products WHERE delivery.bid = '" & id & "' AND products.PID = delivery.pid")
    End Sub

    Public Sub saveDetails(ByVal tnum As String, ByVal pid As Integer, ByVal quantity As Integer)
        CN.Execute("INSERT INTO trans_details SET trans_num = '" & tnum & "', pid = '" & pid & "', quantity = '" & quantity & "'")
    End Sub

    Public Sub getStock(ByVal id As Integer)
        RS = CN.Execute("SELECT prod_stock FROM products WHERE PID = '" & id & "'")
    End Sub

    Public Sub getTrans()
        RS = CN.Execute("SELECT * FROM transactions ORDER BY tid DESC LIMIT 1")
    End Sub

    Public Sub getBatch()
        RS = CN.Execute("SELECT * FROM batch ORDER BY bid DESC LIMIT 1")
    End Sub

    Public Sub getBatch2()
        RS = CN.Execute("SELECT * FROM batch ORDER BY bid DESC")
    End Sub

    Public Sub getBatch3()
        RS = CN.Execute("SELECT * FROM batch WHERE status = 'Open' ORDER BY batch_id DESC")
    End Sub

    Public Sub getTrans2(ByVal d As String)
        RS = CN.Execute("SELECT * FROM transactions, trans_details, products WHERE  products.PID = trans_details.pid AND transactions.transNum = trans_details.trans_num AND transdate = '" & d & "' ORDER BY tid DESC")
    End Sub

    Public Sub getTrans3(ByVal d As String)
        RS = CN.Execute("SELECT * FROM transactions, trans_details, products WHERE  products.PID = trans_details.pid AND transactions.transNum = trans_details.trans_num AND transdate = '" & d & "' ORDER BY empID")
    End Sub

    Public Sub getTrans4(ByVal d As String)
        RS = CN.Execute("SELECT * FROM transactions, trans_details, products WHERE products.PID = trans_details.pid AND transactions.transNum = trans_details.trans_num AND transdate = '" & d & "' ORDER BY tid DESC")
    End Sub

    Public Sub getTrans5(ByVal d As String)
        RS = CN.Execute("SELECT * FROM transactions, trans_details, products WHERE products.PID = trans_details.pid AND transactions.transNum = trans_details.trans_num AND transdate = '" & d & "' ORDER BY empID")
    End Sub

    Public Sub getReceipt(ByVal pd As String)
        RS = CN.Execute("SELECT receipt FROM transactions WHERE transnum = '" & pd & "'")
    End Sub

    Public Sub saveTrans(ByVal transNum As String, ByVal itemCount As Integer, ByVal d As String, ByVal receipt As String)
        CN.Execute("INSERT INTO transactions SET transNum = '" & transNum & "', empID = '" & UserID & "', noOfItemsSold = '" & itemCount & "', total = '" & due & "', transDate = '" & d & "', receipt = '" & receipt & "' ")
    End Sub

    Public Sub getProd1()
        RS = CN.Execute("SELECT * FROM products, delivery WHERE products.PID = delivery.pid  ORDER BY prod_code")
    End Sub

    Public Sub getProd2()
        RS = CN.Execute("SELECT * FROM products, delivery WHERE products.PID = delivery.pid AND  prod_stock <= 15 AND products.prod_stock > 0 ORDER BY prod_code")
    End Sub

    Public Sub getProd3()
        RS = CN.Execute("SELECT * FROM products, delivery WHERE products.PID = delivery.pid AND  prod_stock = 0 ORDER BY prod_code")
    End Sub

    Public Sub getProd4()
        RS = CN.Execute("SELECT * FROM products, delivery WHERE  products.PID = delivery.pid ORDER  BY prod_name")
    End Sub

    Public Sub getProd5()
        RS = CN.Execute("SELECT * FROM products, delivery WHERE products.PID = delivery.pid AND products.prod_stock <= 15 AND products.prod_stock > 0 ORDER BY prod_name")
    End Sub

    Public Sub getProd6()
        RS = CN.Execute("SELECT * FROM products, delivery WHERE products.PID = delivery.pid AND  prod_stock = 0 ORDER BY prod_name")
    End Sub

    Public Sub getProd7()
        RS = CN.Execute("SELECT * FROM products, delivery WHERE  products.PID = delivery.pid ORDER  BY exp_date")
    End Sub

    Public Sub getProd8()
        RS = CN.Execute("SELECT * FROM products, delivery WHERE products.PID = delivery.pid AND products.prod_stock <= 15 AND products.prod_stock > 0 ORDER BY exp_date")
    End Sub

    Public Sub getProd9()
        RS = CN.Execute("SELECT * FROM products, delivery WHERE products.PID = delivery.pid AND  prod_stock = 0 ORDER BY exp_date")
    End Sub

    Public Sub AddDelivery(ByVal prodID As Integer, ByVal additional As Integer, ByVal exp As String, ByVal bid As String)
        CN.Execute("INSERT INTO delivery SET bid = '" & bid & "', pid = '" & prodID & "', items_delivered = '" & additional & "', stock = '" & additional & "', exp_date = '" & exp & "'")
    End Sub

    Public Sub saveBatch(ByVal id As String, ByVal name As String, ByVal dd As String, ByVal dt As String)
        CN.Execute("INSERT INTO batch SET batch_id = '" & id & "', batch_name = '" & name & "', delivery_date = '" & dd & "', delivery_time = '" & dt & "', status = 'Open'")
    End Sub

    Public Sub closeBatch(ByVal id As Integer)
        CN.Execute("UPDATE batch SET status = 'Closed' WHERE bid = '" & id & "'")
    End Sub

    Public Sub getDelivery(ByVal d As String)
        RS = CN.Execute("SELECT * FROM batch WHERE delivery_date = '" & d & "' ORDER BY bid DESC")
    End Sub
End Module
