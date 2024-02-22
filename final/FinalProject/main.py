from email.mime.text import MIMEText
from email.mime.multipart import MIMEMultipart
from email.mime.application import MIMEApplication
import pandas as pd
import mysql.connector
 

def conection_to_bd():
    db_config = {
        'host': '',
        'user': '',
        'password': '',
        'database': '',
    }

    try:
        connection = mysql.connector.connect(**db_config)
        print("Succes conection")
        return connection
    except mysql.connector.Error as err:
        print(f"Error: {err}")
        exit()



def get_info():

    connection = conection_to_bd()

    query = f"SELECT * FROM clientes"



    try:
        df = pd.read_sql_query(query, connection)
        print("SUCCES QUERY")
    except mysql.connector.Error as err:
        print(f"Error: {err}")
        connection.close()
        exit()
        
    connection.close()

    file_path = 'report.xlsx'
    df.to_excel(file_path, index=False, engine='openpyxl')
    print(f"data saved on {file_path}")
    return file_path



def main():
 get_info()

if __name__ == "__main__":
    main()