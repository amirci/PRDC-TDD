msbuild = 'c:\WINDOWS\Microsoft.NET\Framework\v3.5\MSBuild'

msbuild_file = "MavenThought.MovieLibrary.msbuild"

msbuild_cmd = "#{msbuild} #{msbuild_file}"

task :default => [:build]

desc "Builds the project"
task :build do
	call_target msbuild_cmd, :build
end

desc "Cleans the release and debug files"
task :clean do
	call_target msbuild_cmd, :clean
end

desc "Rebuild the application by cleaning and then building"
task :rebuild => [:clean, :build] do
	#nothing to do....
end

namespace :test do

	desc "Builds and then runs all the tests under test folder"
	task :all => [:build] do
		call_target msbuild_cmd, :test
	end

	desc "Runs the test class that matches the name"
	task :class, [:testee] => [:build] do |t, args|
		call_target msbuild_cmd, :testclass, "Testee=#{args.testee}"
	end
	
	desc "Runs the test for an assembly"
	task :assembly, [:testee] => [:build] do |t, args|
		call_target msbuild_cmd, :testassembly, "Testee=#{args.testee}"
	end
	
	desc "Runs the test for a feature (tagee without @)"
	task :feature, [:tagee] => [:build] do |t, args|
		call_target msbuild_cmd, :feature, "Tag=#{args.tagee}"
	end

	desc "Runs all the features tests"
	task :features => [:build] do 
		call_target msbuild_cmd, :features
	end
end

namespace :tools do

	desc "Runs stylecop and generates a report on the Output folder"
	task :stylecop do
		call_target msbuild_cmd, :stylecop
	end
	
end

desc "Builds, Tests and then deploy the library as .zip to the deploy folder"
task :deploy do
	call_target msbuild_cmd, :deploy
end

desc "Changes assemlbies version to the one specified"
task :release, [:version] do |t, args|
	call_target msbuild_cmd, :UpdateAssemblyVersion, "Version=#{args.version}" 
end

def call_target cmd, target_name, parameters = nil
	line = "#{cmd} /t:#{target_name}"
	line = line.concat " /p:#{parameters}" unless parameters.nil?
	sh line
end


