<!DOCTYPE html>
<html>
   <head>
      <meta charset = "UTF-8">
      <meta http-equiv = "X-UA-Compatible" content = "IE = edge,chrome = 1">
      <title>Hello World using Backbone.js</title>
      <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.5/css/bootstrap.min.css" rel="stylesheet"/>
      <link href="https://cdnjs.cloudflare.com/ajax/libs/datatables/1.10.12/css/dataTables.bootstrap4.min.css" rel="stylesheet"/>
   </head>

   <body>
   <?php 
   require_once("dbinfo.inc.php")
   ?>
      <div class="container"> <h1>Homebrew Title ID Database</h1> <table id="example" class="table table-striped table-inverse table-bordered table-hover" cellspacing="0" width="100%"> 
      <thead> 
        <tr> 
          <th>Application ID</th> 
          <th>Application Name</th> 
          <th>Application Type</th> 
          <th>Version Number</th> 
          <th>Website(optional)</th> 
        </tr>
      </thead> 
        <tfoot> 
          <tr> 
			  <th>Application ID</th> 
			  <th>Application Name</th> 
			  <th>Application Type</th> 
			  <th>Version Number</th> 
			  <th>Website(optional)</th> 
          </tr>
        </tfoot> 
        <tbody> 
		<?php 
		$q="select * from Applications;";
		$r=mysqli_query($conn,$q) or die(mysqli_error($conn)." Q=".$q);
		while ($row = $r->fetch_assoc()) { ?>
		<tr>
			<td><?php echo $row["AppID"]; ?></td>
			<td><?php echo $row["AppName"]; ?></td>
			<td><?php echo $typeArray[$row["AppType"]];?></td>
			<td><?php echo $row["AppVersion"];?></td>
			<td><?php echo $row["Website"];?></td>
			
		</tr>
	<?php } ?>
        </tbody> 
        </table>
      </div>
      <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script><script src="https://cdnjs.cloudflare.com/ajax/libs/datatables/1.10.12/js/jquery.dataTables.min.js"></script><script src="https://cdnjs.cloudflare.com/ajax/libs/datatables/1.10.13/js/dataTables.bootstrap4.min.js"></script>
      <script type="text/javascript">
        $(document).ready(function() {
  $('#example').DataTable();
});
      </script>
   </body>
</html>
